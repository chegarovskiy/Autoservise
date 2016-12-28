using System;
using CarService.Core.DataAccessLayer;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Interface to be implemented by PaymentBusinessLogic
    /// </summary>
    public interface IPaymentBusinessLogic : IBaseBusinessLogic<Payment>
    {
         // method to pay order
        bool PayOrder(Guid orderId, Guid paymentTypeId, double sum);
    }
}