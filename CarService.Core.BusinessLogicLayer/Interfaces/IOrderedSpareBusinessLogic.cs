using System;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Inerface to be implemented by OrderedSpareBusinessLogic
    /// </summary>
    public interface IOrderedSpareBusinessLogic : IBaseBusinessLogic<OrderedSpare>
    {
        // functionality to add spare to the order
        bool AddSpareToOrder(Guid orderId, Guid sellerId, Guid spareId, int spareNumber);
        // cancel particular spare number from the order
        bool CancelSpare(Guid orderId, Guid spareId, int spareNumber);
    }
}