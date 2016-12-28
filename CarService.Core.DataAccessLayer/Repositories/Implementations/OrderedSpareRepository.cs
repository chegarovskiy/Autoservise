using System;
using System.Data.Entity;
using System.Linq;
using CarService.Core.BusinessLogicLayer;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer
{
    /// <summary>
    /// Repository to work with ordered spares
    /// Extands BaseRepository
    /// </summary>
    public class OrderedSpareRepository : BaseRepository<OrderedSpare>, IOrderedSpareRepository
    {
        // check if we have enough spares to sell
        public Spare SpareToSell(Guid spareId, int spareCount)
        {
            var spare = ContextDb.Spares.Where(x => x.Id == spareId)
                                        .Include(x => x.Manufacturer)
                                        .Include(x => x.Currency)
                                        .FirstOrDefault();
            if (spare == null || spare.Quantity < spareCount || spare.IsDeleted)
            {
                return null;
            }

            spare.Quantity -= spareCount;
            return spare;
        }

        // order to which the spare will be added
        public Order BaseOrder(Guid orderId)
        {
            return ContextDb.Orders.Where(x => x.Id == orderId)
                .Include(x => x.OrderedSpares)
                .Include(x => x.OrderedServices)
                .Include(x => x.Client)
                .FirstOrDefault();
        }

        // return user who sells the spare
        public User Seller(Guid userId)
        {
            return ContextDb.Users.FirstOrDefault(x => x.Id == userId);
        }

        // Change order status to draft if there are no spares/services there
        public OrderStatus OrderStatusToDraft()
        {
            return ContextDb.OrderStatuses.FirstOrDefault(x => x.Name.Equals(OrderCurrentStatus.Draft.ToString()));
        }

        // Change order status to draft if there are no spares/services there
        public OrderStatus OrderStatusToNew()
        {
            return ContextDb.OrderStatuses.FirstOrDefault(x => x.Name.Equals(OrderCurrentStatus.New.ToString()));
        }
    }
}