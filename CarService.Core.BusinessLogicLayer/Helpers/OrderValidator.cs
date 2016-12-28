using System;
using System.Linq;
using CarService.Core.DataAccessLayer;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Validate order functionality
    /// </summary>
    public static class OrderValidator
    {
        // check if order contains spares
        public static bool IsAddedSpare(this Order order, Guid spareId)
        {
            return order.OrderedSpares.Any(spareInOrder => spareInOrder.Spare.Id == spareId);
        }

        // check if the order will be fully-pai
        public static bool IsPaidInFull(this Order order, double sum)
        {
            // compare order price and amount of money client pays
            return order.TotalPrice.Equals(sum);
        }
    }
}