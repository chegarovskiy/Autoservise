using System;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by PaymentRepository
    /// </summary>
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        // find order to be paid
        Order BaseOrder(Guid orderId);
        // get payment method from the db
        PaymentType ChosenPaymentType(Guid paymentTypeId);
    }
}