using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CarService.Core.BusinessLogicLayer;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer
{
    /// <summary>
    /// Repository to work with ordered services
    /// Extands BaseRepository
    /// </summary>
    public class OrderedServiceRepository : BaseRepository<OrderedService>, IOrderedServiceRepository
    {
        // check if we provide ordered service
        public Service ServiceToProvide(Guid serviceId)
        {
            var service = ContextDb.Services.Where(x => x.Id == serviceId)
                                        .Include(x => x.ServiceType)
                                        .FirstOrDefault();

            if (service == null || service.IsDeleted)
            {
                return null;
            }

            return service;
        }

        // order to which the service will be added
        public Order BaseOrder(Guid orderId)
        {
            return ContextDb.Orders.Where(x => x.Id == orderId)
                .Include(x => x.OrderedSpares)
                .Include(x => x.OrderedServices)
                .Include(x => x.Client)
                .FirstOrDefault();
        }

        // return user who provides the spare
        public User Master(Guid userId)
        {
            return ContextDb.Users.FirstOrDefault(x => x.Id == userId);
        }

        // returns all ordered services assigned to an employee on a day or just all on a day
        public List<OrderedService> DayEmployeeOrAllOrderedServices(Guid employeeId, DateTime date)
        {
            return ContextDb.OrderedServices
                .Where(x => (employeeId == Guid.Empty || x.User.Id == employeeId)
                            && (x.Order.StartDate.Year == date.Year
                                && x.Order.StartDate.Month == date.Month
                                && x.Order.StartDate.Day == date.Day))
                .ToList();
        }

        // returns all ordered services assigned to an employee on a day
        public List<OrderedService> MonthEmployeeOrAllOrderedServices(Guid employeeId, DateTime date)
        {
            return ContextDb.OrderedServices
                .Where(x => (employeeId == Guid.Empty || x.User.Id == employeeId)
                            && (x.Order.StartDate.Year == date.Year
                                && x.Order.StartDate.Month == date.Month))
                .ToList();
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