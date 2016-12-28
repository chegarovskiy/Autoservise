using System;
using System.Linq;
using CarService.Core.BusinessLogicLayer;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by Order repository
    /// </summary>
    public interface IOrderRepository : IBaseRepository<Order>
    {
        // method to connect a client to an order
        Client ConnectClient(Guid clientId);
        // check if we have enough spares to sell
        Spare SpareToSell(Guid spareId, int spareCount);
        // return user who sells the spare
        User Seller(Guid userId);
        // get all client's orders
        IQueryable<Order> GetClientOrders(Guid clientId);
        // change order status
        OrderStatus ChangeOrderStatus(string status);
    }
}