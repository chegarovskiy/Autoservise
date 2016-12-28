using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CarService.Core.BusinessLogicLayer;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer
{
    /// <summary>
    /// Repository to work with orders
    /// Extands BaseRepository
    /// </summary>
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        // connect order to a particular client
        public Client ConnectClient(Guid clientId)
        {
            return ContextDb.Client.FirstOrDefault(x => x.Id == clientId);
        }

        // check if we have enough spares to sell
        public Spare SpareToSell(Guid spareId, int spareCount)
        {
            var spare = ContextDb.Spares.Where(x => x.Id == spareId)
                                        .Include(x => x.Manufacturer)
                                        .Include(x => x.Currency)
                                        .FirstOrDefault();
            if (spare == null || spare.Quantity < spareCount)
            {
                return null;
            }

            spare.Quantity -= spareCount;
            return spare;
        }

        // return user who sells the spare
        public User Seller(Guid userId)
        {
            return ContextDb.Users.FirstOrDefault(x => x.Id == userId);
        }

        // ToDo come back here
        // get order by identifier
        public new Order GetById(Guid userOrderId)
        {
            return ContextDb.Orders.Where(x => x.Id == userOrderId)
                                    .Include(x => x.OrderedSpares
                                        .Select(w => w.Spare))
                                    .Include(x => x.OrderedSpares
                                        .Select(w => w.Spare.Manufacturer))
                                    .Include(x => x.OrderedSpares
                                        .Select(w => w.Spare.Currency))
                                    .Include(x => x.OrderedServices)
                                    .FirstOrDefault();
        }

        // return all client's orders
        public IQueryable<Order> GetClientOrders(Guid clientId)
        {
            return Get(x => x.Client.Id == clientId)
                        .Include(x => x.Client)
                        .Include(x => x.OrderedServices)
                        .Include(x => x.OrderedSpares);
        }

        // Change order status
        // ToDo come back here and change to code
        public OrderStatus ChangeOrderStatus(string status)
        {
            return ContextDb.OrderStatuses.FirstOrDefault(x => x.Name.Equals(status));
        }
    }
}