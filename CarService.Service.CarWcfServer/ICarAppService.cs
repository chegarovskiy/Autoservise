using System;
using System.Collections.Generic;
using System.ServiceModel;
using CarService.Core.BusinessLogicLayer;
using CarService.Core.Entities;

namespace CarService.Service.CarWcfServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarAppService" in both code and config file together.
    [ServiceContract]
    public interface ICarAppService
    {
        //return int as Order Id
        [OperationContract]
        Guid AddOrGetOrder(Guid clientId, Guid orderId);

        [OperationContract]
        void AddSparetoOrder(Guid orderId, Guid sellerId, Guid spareId, int spareCount);

        [OperationContract]
        bool AddServicetoOrder(Guid orderId, Guid serviceId, Guid userId, double? servicePrice);

        [OperationContract]
        void CancelOrder(Guid orderId);

        [OperationContract]
        bool CancelSpareFromOrder(Guid orderId, Guid spareId, int spareNumber);

        [OperationContract]
        bool DeleteServiceFromOrder(Guid orderId, Guid serviceId);

        [OperationContract]
        IEnumerable<Order> GetClientsOrders(Guid clientId);

        [OperationContract]
        IEnumerable<Order> GetAllOrders();

        //source is a string - absolute way to data source file with
        [OperationContract]
        int LoadPrice(string source);

        [OperationContract]
        IEnumerable<WorkType> GetWorkTypes();

        [OperationContract]
        IEnumerable<Spare> GetSpares();

        [OperationContract]
        IEnumerable<OrderedService> GetUserOrdersForPeriod(Guid employeeId, DateTime selectedDate, TimePeriod timePeriod);


    }
}
