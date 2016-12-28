using System;
using System.Collections.Generic;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Interfaces
{
    /// <summary>
    /// Inerface to be implemented by OrderedServiceRepository
    /// </summary>
    public interface IOrderedServiceRepository : IBaseRepository<OrderedService>
    {
        // check service in the DB
        Service ServiceToProvide(Guid serviceId);
        // find order to which the service will be added
        Order BaseOrder(Guid orderIdentifier);
        // find user who will provide a service
        User Master(Guid userId);
        // returns ordered services by an employee
        List<OrderedService> DayEmployeeOrAllOrderedServices(Guid employeeId, DateTime date);
        // returns ordered services by an employee
        List<OrderedService> MonthEmployeeOrAllOrderedServices(Guid employeeId, DateTime date);
        // change order status in case there are no spares or services left there
        OrderStatus OrderStatusToDraft();
        // change order status to new if we ad new spare to order
        OrderStatus OrderStatusToNew();
    }
}