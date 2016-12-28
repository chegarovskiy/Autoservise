using System;
using System.Data.Entity;
using System.Linq;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer
{
    /// <summary>
    /// Repository to work with payments
    /// </summary>
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        // get order to be paid
        public Order BaseOrder(Guid orderId)
        {
            return ContextDb.Orders.Where(x => x.Id == orderId)
                .Include(x => x.OrderedSpares)
                .Include(x => x.OrderedServices)
                .Include(x => x.Client)
                .FirstOrDefault();
        }

        // get pament type from the db
        public PaymentType ChosenPaymentType(Guid paymentTypeId)
        {
            return ContextDb.PaymentTypes.FirstOrDefault(x => x.Id == paymentTypeId);
        }
    }
}