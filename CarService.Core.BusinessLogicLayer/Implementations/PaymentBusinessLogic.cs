using System;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Business Logic to pay orders
    /// </summary>
    public class PaymentBusinessLogic : BaseBusinessLogic<IPaymentRepository, Payment>, IPaymentBusinessLogic
    {
        public PaymentBusinessLogic(IPaymentRepository repository) : base(repository)
        {
        }

        // functionality to pay order
        public bool PayOrder(Guid orderId, Guid paymentTypeId, double sum)
        {
            // get order from DB
            var order = Repository.BaseOrder(orderId);
            
            // check if the order is ready to be paid
            // invalid if: there is no such order in the db // total order price ==0 // order is paid // entered sum > order price
            if (order == null || order.IsPaid || Math.Abs(order.TotalPrice) < 0.001 || order.TotalPrice < sum)
            {
                return false;
            }

            // check if the payment type is valid
            var paymentType = Repository.ChosenPaymentType(paymentTypeId);

            if (paymentType == null)
            {
                return false;
            }

            // check if we can close the order
            if (order.IsPaidInFull(sum))
            {
                order.IsPaid = true;
                //todo do not work line above
                //order.OrderStatus = Repository.CompleteOrder();
            }
            
            // create new payment
            var payment = new Payment()
            {
                Order = order,
                Summ = sum,
                PaymentType = paymentType
            };

            payment.Order.Payments.Add(payment);

            Insert(payment);
            return true;
        }
    }
}