using System;
using System.Collections.Generic;
using CarService.Core.DataAccessLayer;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Interface to be implemented by OrderBusinessLogic class
    /// derived from IBaseBusinessLogic interface
    /// </summary>
    public interface IOrderBusinessLogic : IBaseBusinessLogic<Order>
    {
        // add new order by received parameters
        Guid AddOrGetOrder(Guid clientId, Guid orderId);
        // cancelling current order
        void CancelOrder(Guid orderId);
        // functionality to add spare to the order
        bool AddSpareToOrder(Guid orderId, Guid sellerId, Guid spareId, int spareCount);
        // cancel particular spare number from the order
        bool CancelSpare(Guid orderId, Guid spareId, int spareNumber);
        // functionality to add spare to the order
        bool AddServiceToOrder(Guid orderId, Guid serviceId, Guid userId, double? servicePrice);
        // cancel a service from the order
        bool CancelService(Guid orderId, Guid serviceId);
        // get all orders of a client
        List<Order> ClientOrders(Guid clientId);
        // get all orders from the DB
        List<Order> AllOrders();
        // pay for the order
        bool PayOrder(Guid orderId, Guid paymentTypeId, double sum);

        //ToDo think about methods to extract spares and services from the DB
    }
}