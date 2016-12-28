using System;
using CarService.Core.BusinessLogicLayer;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by OrderSpare repository
    /// </summary>
    public interface IOrderedSpareRepository : IBaseRepository<OrderedSpare>
    {
        // check spare in the DB
        Spare SpareToSell(Guid spareId, int spareNumber);
        // find order to which the spare will be added
        Order BaseOrder(Guid orderIdentifier);
        // find user who sells a spare
        User Seller(Guid userId);
        // change order status in case there are no spares or services left there
        OrderStatus OrderStatusToDraft();
        // change order status to new if we ad new spare to order
        OrderStatus OrderStatusToNew();
    }
}