using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CarService.Core.DataAccessLayer;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Business logic to work with orders
    /// </summary>
    public class OrderBusinessLogic : BaseBusinessLogic<IOrderRepository, Order>, IOrderBusinessLogic
    {
        // business logic to work with ordered spares
        private readonly IOrderedSpareBusinessLogic _orderedSpareBl;
        // business logic to work with ordered services
        private readonly IOrderedServiceBusinessLogic _orderedServiceBl;
        //business logic to work with order payments
        private readonly IPaymentBusinessLogic _paymentBl;

        // class constructor
        public OrderBusinessLogic(IOrderRepository repository, IOrderedSpareBusinessLogic orderedSpareBl, 
            IOrderedServiceBusinessLogic orderedServiceBl, IPaymentBusinessLogic paymentBl) : base(repository)
        {
            _orderedSpareBl = orderedSpareBl;
            _orderedServiceBl = orderedServiceBl;
            _paymentBl = paymentBl;
        }

        // functionality to add order. If order exists, user will receive error message
        public Guid AddOrGetOrder(Guid clientId, Guid orderId)
        {
            // try to get order by ID from db
            var order = Get(x => x.Id == orderId).FirstOrDefault();

            // check if there was an order
            if (order != null)
            {
                // if yes, continue working with the order
                return order.Id;
            }

            // if not, create new order
            order = new Order()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                OrderStatus = Repository.ChangeOrderStatus(OrderCurrentStatus.Draft.ToString()),
                TotalPrice = 0,
                IsPaid = false,
                IsDeleted = false,
                Client = Repository.ConnectClient(clientId)
            };

            Insert(order);
            return order.Id;
        }

        // Cancelling order
        public void CancelOrder(Guid orderId)
        {
            Repository = new OrderRepository();
            // getting order from the DB
            var order = Repository.GetById(orderId);

            // if the order is present
            if (order != null)
            {
                foreach (var orderedSpare in order.OrderedSpares)
                {
                    orderedSpare.Spare.Quantity += orderedSpare.Count;
                }
                order.OrderStatus = Repository.ChangeOrderStatus(OrderCurrentStatus.Completed.ToString());
                order.IsDeleted = true;
                Update(order);
            }
        }

        // add spare to the order
        public bool AddSpareToOrder(Guid orderId, Guid sellerId, Guid spareId, int spareCount)
        {
            return _orderedSpareBl.AddSpareToOrder(orderId, sellerId, spareId, spareCount);           
        }

        // cancel one or all spares from order
        public bool CancelSpare(Guid orderId, Guid spareId, int spareNumber)
        {
            return _orderedSpareBl.CancelSpare(orderId, spareId, spareNumber);
        }

        // add service to order
        public bool AddServiceToOrder(Guid orderId, Guid serviceId, Guid userId, double? servicePrice)
        {
            return _orderedServiceBl.AddServiceToOrder(orderId, serviceId, userId, servicePrice);
        }

        // cancel order from order
        public bool CancelService(Guid orderId, Guid serviceId)
        {
            return _orderedServiceBl.CancelService(orderId, serviceId);
        }

        // get all client's orders
        public List<Order> ClientOrders(Guid clientId)
        {
            return Repository.GetClientOrders(clientId).ToList();
        }

        // get all orders from the dB
        public List<Order> AllOrders()
        {
            return Repository.GetAll().ToList();
        }

        // functionality to pay order
        public bool PayOrder(Guid orderId, Guid paymentTypeId, double sum)
        {
            return _paymentBl.PayOrder(orderId, paymentTypeId, sum);
        }
    }
}