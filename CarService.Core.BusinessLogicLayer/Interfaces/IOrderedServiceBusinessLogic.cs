using System;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Inerface to be implemented by OrderedServiceBusinessLogic
    /// </summary>
    public interface IOrderedServiceBusinessLogic : IBaseBusinessLogic<OrderedService>
    {
        // functionality to add service to the order
        bool AddServiceToOrder(Guid orderId, Guid serviceId, Guid userId, double? servicePrice);
        // cancel particular service from the order
        bool CancelService(Guid orderIdentifier, Guid serviceId);
    }
}