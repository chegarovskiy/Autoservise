using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CarService.Core.DataAccessLayer;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Business logic to order services
    /// </summary>
    public class OrderedServiceBusinessLogic : BaseBusinessLogic<IOrderedServiceRepository, OrderedService>,
        IOrderedServiceBusinessLogic
    {
        public OrderedServiceBusinessLogic(IOrderedServiceRepository repository) : base(repository)
        {

        }

        // method to add service to an order
        public bool AddServiceToOrder(Guid orderId, Guid serviceId, Guid userId, double? servicePrice)
        {
            // get order from the DB
            var order = Repository.BaseOrder(orderId);

            // get ordered spare from the DB
            var service = Repository.ServiceToProvide(serviceId);

            if (service == null)
            {
                return false;
            }

            // check if user entered corrected price for a service
            if (servicePrice == null)
            {
                servicePrice = service.BasePrice;
            }

            order.TotalPrice = ((order.TotalPrice*100) + ((double) servicePrice*100))/100;
            order.OrderStatus = Repository.OrderStatusToNew();

            // add newly-ordered service to the order
            var orderedService = new OrderedService()
            {
                Order = order,
                Service = service,
                User = Repository.Master(userId),
                FinalPrice = (double) servicePrice
            };

            Insert(orderedService);

            return true;
        }

        public bool CancelService(Guid serviceId, Guid orderIdentifier)
        {
            // get order from the DB
            var order = Repository.BaseOrder(orderIdentifier);

            // get ordered service
            var service = order.OrderedServices.FirstOrDefault(x => x.Service.Id == serviceId);

            // check if the service is present in the order
            if (service == null)
            {
                return false;
            }

            // change order price
            service.Order.TotalPrice = ((service.Order.TotalPrice*100) - (service.FinalPrice*100))/100;

            if (service.Order.OrderedSpares.Count == 0 || service.Order.OrderedServices.Count == 0)
            {
                service.Order.OrderStatus = Repository.OrderStatusToDraft();
            }
            // remove ordered service
            Remove(service);

            return true;
        }

        // method returns list of employees for a particular selected Date/Week/Month
        public List<OrderedService> GetUserOrdersForPeriod(Guid employeeId, DateTime selectedDate, TimePeriod timePeriod)
        {
            switch (timePeriod)
            {
                case TimePeriod.Day:
                    return Repository.DayEmployeeOrAllOrderedServices(employeeId, selectedDate);

                case TimePeriod.Week:
                    // list will contain all ordered services by user for a week
                    var weekOrderedServices = new List<OrderedService>();

                    #region Get days for a chosen week for which we will be selecting data from the DB

                    int currentDayOfWeek = (int) selectedDate.DayOfWeek;
                    DateTime sunday = selectedDate.AddDays(-currentDayOfWeek);
                    DateTime monday = sunday.AddDays(1);
                    // If we started on Sunday, we should go *back*
                    // 6 days instead of forward 1...
                    if (currentDayOfWeek == 0)
                    {
                        monday = monday.AddDays(-7);
                    }
                    var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();

                    #endregion

                    // once we have dates, we may select values from the DB day by day
                    foreach (var date in dates)
                    {
                        var orderedServicesForDate = Repository.DayEmployeeOrAllOrderedServices(employeeId, date);
                        if (orderedServicesForDate.Count > 0)
                        {
                            weekOrderedServices.AddRange(orderedServicesForDate);
                        }
                    }

                    // if there are no services ordered for selected dates, return null
                    if (weekOrderedServices.Count == 0)
                    {
                        return null;
                    }
                    //otherwice return found services
                    return weekOrderedServices;

                case TimePeriod.Month:
                    return Repository.MonthEmployeeOrAllOrderedServices(employeeId, selectedDate);
            }
            // return null if something goes wrong
            return null;
        }

        public IEnumerable<OrderedService> GetAllOrderedServices()
        {
            try
            {
                var orderedService = new BaseRepository<OrderedService>().GetAll().ToList();
                return orderedService;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}