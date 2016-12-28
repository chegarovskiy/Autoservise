using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CarService.Core.DataAccessLayer;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Business logic to order spares
    /// </summary>
    public class OrderedSpareBusinessLogic : BaseBusinessLogic<IOrderedSpareRepository, OrderedSpare>,
        IOrderedSpareBusinessLogic
    {

        public OrderedSpareBusinessLogic(IOrderedSpareRepository repository) : base(repository)
        {

        }

        public bool AddSpareToOrder(Guid orderId, Guid sellerId, Guid spareId, int spareNumber)
        {
            // get order from the DB
            var order = Repository.BaseOrder(orderId);

            // if there is no such order in the DB
            if (order == null)
            {
                return false;
            }

            // get spare from the DB
            var spare = Repository.SpareToSell(spareId, spareNumber);

            // if there are not enough spares in the DB
            // or such spare does not exist
            if (spare == null)
            {
                return false;
            }

            double usedMarkup;
            // summing price for all spares
            var orderedSparesPrice = spare.OrderedSparePrice(spareNumber, out usedMarkup);
            // update order total price
            order.TotalPrice = Math.Round(((order.TotalPrice*100) + (orderedSparesPrice*100))/100, 2);

            // if we didn't find the spare
            if (!order.IsAddedSpare(spareId))
            {
                var orderedSpare = new OrderedSpare()
                {
                    Order = order,
                    Spare = spare,
                    Count = spareNumber,
                    User = Repository.Seller(sellerId),
                    PriceForAll = orderedSparesPrice,
                    UsedMarkup = usedMarkup,
                    Currency = spare.Currency,
                    ExchangeRate = spare.Currency.ExchangeRate
                };
                orderedSpare.Order.OrderStatus = Repository.OrderStatusToNew();
                Repository.Insert(orderedSpare);
            }
            // if there is spare in the order
            else
            {
                var orderToUpdate = Repository.Get(x => x.Order.Id == orderId)
                    .Include(x => x.User.Id == sellerId)
                    .FirstOrDefault();

                orderToUpdate.Count += spareNumber;
                orderToUpdate.Order.OrderStatus = Repository.OrderStatusToNew();
                Repository.Update(orderToUpdate);
            }
            return true;
        }

        public bool CancelSpare(Guid orderId, Guid spareId, int spareNumber)
        {
            // get order from the DB
            var order = Repository.BaseOrder(orderId);

            // find ordered spare
            var orderedSpare = order.OrderedSpares.FirstOrDefault(x => x.Spare.Id == spareId);

            // check if the spare is present in the order
            // and if the number of spares to remove from order is not valid
            if (orderedSpare == null || orderedSpare.Count < spareNumber)
            {
                return false;
            }

            // restore spares count in the DB
            orderedSpare.Count -= spareNumber;
            // change order price
            orderedSpare.Order.TotalPrice = ((orderedSpare.Order.TotalPrice*100) - (orderedSpare.PriceForAll*100))/100;

            double usedMarkup;
            // summing price for all spares
            orderedSpare.PriceForAll = orderedSpare.Spare.OrderedSparePrice(spareNumber, out usedMarkup);
            // update order price
            orderedSpare.Order.TotalPrice =
                Math.Round(((orderedSpare.Order.TotalPrice*100) + (orderedSpare.PriceForAll*100))/100, 2);

            // change number of ordered spares
            orderedSpare.Spare.Quantity += spareNumber;

            // update order
            Update(orderedSpare);

            // remove cancelled ordered spare if its count == 0
            if (orderedSpare.Count == 0)
            {
                if (orderedSpare.Order.OrderedSpares.Count == 0 || orderedSpare.Order.OrderedServices.Count == 0)
                {
                    orderedSpare.Order.OrderStatus = Repository.OrderStatusToDraft();
                }
                Remove(orderedSpare);
            }
            return true;
        }

        public IEnumerable<OrderedSpare> GetAllOrderedSpares()
        {
            try
            {
                var orderedSpares = new BaseRepository<OrderedSpare>().GetAll().ToList();
                return orderedSpares;
            }
            catch (Exception)
            {

                return null;
            }
            
        }
    }
}