﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarService.Interface.Client.CarServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CarServiceReference.ICarAppService")]
    public interface ICarAppService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/AddOrGetOrder", ReplyAction="http://tempuri.org/ICarAppService/AddOrGetOrderResponse")]
        System.Guid AddOrGetOrder(System.Guid clientId, System.Guid orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/AddOrGetOrder", ReplyAction="http://tempuri.org/ICarAppService/AddOrGetOrderResponse")]
        System.Threading.Tasks.Task<System.Guid> AddOrGetOrderAsync(System.Guid clientId, System.Guid orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/AddSparetoOrder", ReplyAction="http://tempuri.org/ICarAppService/AddSparetoOrderResponse")]
        void AddSparetoOrder(System.Guid orderId, System.Guid sellerId, System.Guid spareId, int spareCount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/AddSparetoOrder", ReplyAction="http://tempuri.org/ICarAppService/AddSparetoOrderResponse")]
        System.Threading.Tasks.Task AddSparetoOrderAsync(System.Guid orderId, System.Guid sellerId, System.Guid spareId, int spareCount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/AddServicetoOrder", ReplyAction="http://tempuri.org/ICarAppService/AddServicetoOrderResponse")]
        bool AddServicetoOrder(System.Guid orderId, System.Guid serviceId, System.Guid userId, System.Nullable<double> servicePrice);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/AddServicetoOrder", ReplyAction="http://tempuri.org/ICarAppService/AddServicetoOrderResponse")]
        System.Threading.Tasks.Task<bool> AddServicetoOrderAsync(System.Guid orderId, System.Guid serviceId, System.Guid userId, System.Nullable<double> servicePrice);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/CancelOrder", ReplyAction="http://tempuri.org/ICarAppService/CancelOrderResponse")]
        void CancelOrder(System.Guid orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/CancelOrder", ReplyAction="http://tempuri.org/ICarAppService/CancelOrderResponse")]
        System.Threading.Tasks.Task CancelOrderAsync(System.Guid orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/CancelSpareFromOrder", ReplyAction="http://tempuri.org/ICarAppService/CancelSpareFromOrderResponse")]
        bool CancelSpareFromOrder(System.Guid orderId, System.Guid spareId, int spareNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/CancelSpareFromOrder", ReplyAction="http://tempuri.org/ICarAppService/CancelSpareFromOrderResponse")]
        System.Threading.Tasks.Task<bool> CancelSpareFromOrderAsync(System.Guid orderId, System.Guid spareId, int spareNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/DeleteServiceFromOrder", ReplyAction="http://tempuri.org/ICarAppService/DeleteServiceFromOrderResponse")]
        bool DeleteServiceFromOrder(System.Guid orderId, System.Guid serviceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/DeleteServiceFromOrder", ReplyAction="http://tempuri.org/ICarAppService/DeleteServiceFromOrderResponse")]
        System.Threading.Tasks.Task<bool> DeleteServiceFromOrderAsync(System.Guid orderId, System.Guid serviceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/GetClientsOrders", ReplyAction="http://tempuri.org/ICarAppService/GetClientsOrdersResponse")]
        CarService.Core.Entities.Order[] GetClientsOrders(System.Guid clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/GetClientsOrders", ReplyAction="http://tempuri.org/ICarAppService/GetClientsOrdersResponse")]
        System.Threading.Tasks.Task<CarService.Core.Entities.Order[]> GetClientsOrdersAsync(System.Guid clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/GetAllOrders", ReplyAction="http://tempuri.org/ICarAppService/GetAllOrdersResponse")]
        CarService.Core.Entities.Order[] GetAllOrders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/GetAllOrders", ReplyAction="http://tempuri.org/ICarAppService/GetAllOrdersResponse")]
        System.Threading.Tasks.Task<CarService.Core.Entities.Order[]> GetAllOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/LoadPrice", ReplyAction="http://tempuri.org/ICarAppService/LoadPriceResponse")]
        int LoadPrice(string source);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/LoadPrice", ReplyAction="http://tempuri.org/ICarAppService/LoadPriceResponse")]
        System.Threading.Tasks.Task<int> LoadPriceAsync(string source);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/GetWorkTypes", ReplyAction="http://tempuri.org/ICarAppService/GetWorkTypesResponse")]
        CarService.Core.Entities.WorkType[] GetWorkTypes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/GetWorkTypes", ReplyAction="http://tempuri.org/ICarAppService/GetWorkTypesResponse")]
        System.Threading.Tasks.Task<CarService.Core.Entities.WorkType[]> GetWorkTypesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/GetSpares", ReplyAction="http://tempuri.org/ICarAppService/GetSparesResponse")]
        CarService.Core.Entities.Spare[] GetSpares();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarAppService/GetSpares", ReplyAction="http://tempuri.org/ICarAppService/GetSparesResponse")]
        System.Threading.Tasks.Task<CarService.Core.Entities.Spare[]> GetSparesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICarAppServiceChannel : CarService.Interface.Client.CarServiceReference.ICarAppService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CarAppServiceClient : System.ServiceModel.ClientBase<CarService.Interface.Client.CarServiceReference.ICarAppService>, CarService.Interface.Client.CarServiceReference.ICarAppService {
        
        public CarAppServiceClient() {
        }
        
        public CarAppServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CarAppServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CarAppServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CarAppServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Guid AddOrGetOrder(System.Guid clientId, System.Guid orderId) {
            return base.Channel.AddOrGetOrder(clientId, orderId);
        }
        
        public System.Threading.Tasks.Task<System.Guid> AddOrGetOrderAsync(System.Guid clientId, System.Guid orderId) {
            return base.Channel.AddOrGetOrderAsync(clientId, orderId);
        }
        
        public void AddSparetoOrder(System.Guid orderId, System.Guid sellerId, System.Guid spareId, int spareCount) {
            base.Channel.AddSparetoOrder(orderId, sellerId, spareId, spareCount);
        }
        
        public System.Threading.Tasks.Task AddSparetoOrderAsync(System.Guid orderId, System.Guid sellerId, System.Guid spareId, int spareCount) {
            return base.Channel.AddSparetoOrderAsync(orderId, sellerId, spareId, spareCount);
        }
        
        public bool AddServicetoOrder(System.Guid orderId, System.Guid serviceId, System.Guid userId, System.Nullable<double> servicePrice) {
            return base.Channel.AddServicetoOrder(orderId, serviceId, userId, servicePrice);
        }
        
        public System.Threading.Tasks.Task<bool> AddServicetoOrderAsync(System.Guid orderId, System.Guid serviceId, System.Guid userId, System.Nullable<double> servicePrice) {
            return base.Channel.AddServicetoOrderAsync(orderId, serviceId, userId, servicePrice);
        }
        
        public void CancelOrder(System.Guid orderId) {
            base.Channel.CancelOrder(orderId);
        }
        
        public System.Threading.Tasks.Task CancelOrderAsync(System.Guid orderId) {
            return base.Channel.CancelOrderAsync(orderId);
        }
        
        public bool CancelSpareFromOrder(System.Guid orderId, System.Guid spareId, int spareNumber) {
            return base.Channel.CancelSpareFromOrder(orderId, spareId, spareNumber);
        }
        
        public System.Threading.Tasks.Task<bool> CancelSpareFromOrderAsync(System.Guid orderId, System.Guid spareId, int spareNumber) {
            return base.Channel.CancelSpareFromOrderAsync(orderId, spareId, spareNumber);
        }
        
        public bool DeleteServiceFromOrder(System.Guid orderId, System.Guid serviceId) {
            return base.Channel.DeleteServiceFromOrder(orderId, serviceId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteServiceFromOrderAsync(System.Guid orderId, System.Guid serviceId) {
            return base.Channel.DeleteServiceFromOrderAsync(orderId, serviceId);
        }
        
        public CarService.Core.Entities.Order[] GetClientsOrders(System.Guid clientId) {
            return base.Channel.GetClientsOrders(clientId);
        }
        
        public System.Threading.Tasks.Task<CarService.Core.Entities.Order[]> GetClientsOrdersAsync(System.Guid clientId) {
            return base.Channel.GetClientsOrdersAsync(clientId);
        }
        
        public CarService.Core.Entities.Order[] GetAllOrders() {
            return base.Channel.GetAllOrders();
        }
        
        public System.Threading.Tasks.Task<CarService.Core.Entities.Order[]> GetAllOrdersAsync() {
            return base.Channel.GetAllOrdersAsync();
        }
        
        public int LoadPrice(string source) {
            return base.Channel.LoadPrice(source);
        }
        
        public System.Threading.Tasks.Task<int> LoadPriceAsync(string source) {
            return base.Channel.LoadPriceAsync(source);
        }
        
        public CarService.Core.Entities.WorkType[] GetWorkTypes() {
            return base.Channel.GetWorkTypes();
        }
        
        public System.Threading.Tasks.Task<CarService.Core.Entities.WorkType[]> GetWorkTypesAsync() {
            return base.Channel.GetWorkTypesAsync();
        }
        
        public CarService.Core.Entities.Spare[] GetSpares() {
            return base.Channel.GetSpares();
        }
        
        public System.Threading.Tasks.Task<CarService.Core.Entities.Spare[]> GetSparesAsync() {
            return base.Channel.GetSparesAsync();
        }
    }
}
