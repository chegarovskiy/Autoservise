using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CarService.Core.BusinessLogicLayer;
using CarService.Core.DataAccessLayer;
using CarService.Core.Entities;

namespace CarService.Service.CarWcfServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CarAppService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CarAppService.svc or CarAppService.svc.cs at the Solution Explorer and start debugging.
    public class CarAppService : ICarAppService
    {
        private readonly OrderBusinessLogic _orderLogic;

        public CarAppService()
        {
            _orderLogic = new OrderBusinessLogic(
                new OrderRepository(),
                new OrderedSpareBusinessLogic(new OrderedSpareRepository()),
                new OrderedServiceBusinessLogic(new OrderedServiceRepository()),
                new PaymentBusinessLogic(new PaymentRepository()));
        }


        public Guid AddOrGetOrder(Guid clientId, Guid orderId)
        {

            return _orderLogic.AddOrGetOrder(clientId, orderId);
        }

        public void AddSparetoOrder(Guid orderId, Guid sellerId, Guid spareId, int spareCount)
        {

            _orderLogic.AddSpareToOrder(orderId, sellerId, spareId, spareCount);
        }

        public bool AddServicetoOrder(Guid orderId, Guid serviceId, Guid userId, double? servicePrice)
        {

            return _orderLogic.AddServiceToOrder(orderId, serviceId, userId, servicePrice);
        }

        public void CancelOrder(Guid orderId)
        {

            _orderLogic.CancelOrder(orderId);
        }

        public bool CancelSpareFromOrder(Guid orderId, Guid spareId, int spareNumber)
        {

            return _orderLogic.CancelSpare(orderId, spareId, spareNumber);
        }

        public bool DeleteServiceFromOrder(Guid orderId, Guid serviceId)
        {

            return _orderLogic.CancelService(orderId, serviceId);
        }

        public IEnumerable<Order> GetClientsOrders(Guid clientId)
        {

            return _orderLogic.ClientOrders(clientId);
        }

        public IEnumerable<Order> GetAllOrders()
        {

            return _orderLogic.GetAll();
        }

        public int LoadPrice(string source)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<WorkType> GetWorkTypes()
        {
            try
            {
                return new BaseRepository<WorkType>().GetAll().Include(x => x.Users).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

            
        }

        public IEnumerable<Spare> GetSpares()
        {
            try
            {
                return new BaseRepository<Spare>().GetAll().Include(x => x.Manufacturer).Include(x => x.Currency).ToList();
            }
            catch (Exception)
            {

                return null;
            }
            

        }

        public IEnumerable<OrderedService> GetUserOrdersForPeriod(Guid employeeId, DateTime selectedDate, TimePeriod timePeriod)
        {
            var orderSpare = new OrderedServiceBusinessLogic(new OrderedServiceRepository());
            return orderSpare.GetUserOrdersForPeriod(employeeId, selectedDate, timePeriod);
        }

        public IEnumerable<OrderedSpare> GetAllOrderedSpares()
        {
            var orderSpare = new OrderedSpareBusinessLogic(new OrderedSpareRepository());
            return orderSpare.GetAllOrderedSpares();
        }

        public IEnumerable<OrderedService> GetAllOrderedServices()
        {
            var orderSpare = new OrderedServiceBusinessLogic(new OrderedServiceRepository());
            return orderSpare.GetAllOrderedServices();
        }
    }
}
