using System;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    public static class SpareHelper
    {
        // Method returns sum of the spares to be added to an order
        public static double OrderedSparePrice(this Spare spare, int spareNumber, out double usedMarkup)
        {
            int spareMarkupPercentage = spare.MarkupPercentage;

            var orderedSparesPrice = spare.Price;
            
            // convert currency
            if (spare.Currency.Code != (int)Currencies.UAH)
            {
                orderedSparesPrice = Math.Round((orderedSparesPrice * 10000) * (spare.Currency.ExchangeRate * 10000) / 100000000, 4, MidpointRounding.AwayFromZero);
            }

            // calculate price for ordered number of spares
            orderedSparesPrice = Math.Round(((orderedSparesPrice * 10000) * spareNumber) / 10000, 4, MidpointRounding.AwayFromZero);

            // calculate markup
            if (spareMarkupPercentage > 0)
            {
                usedMarkup = Math.Round(((orderedSparesPrice*10000)*(spareMarkupPercentage))/1000000, 4, MidpointRounding.AwayFromZero);
            }
            else
            {
                usedMarkup = 0.0;
            }

            // calculate the final price
            orderedSparesPrice = Math.Round((((orderedSparesPrice * 100) + (usedMarkup * 100)) / 100), 2, MidpointRounding.AwayFromZero);
            
            return orderedSparesPrice;
        }

        // check spare currency
        public static double SpareCurrencyExchangeRate(
            this Spare spare, 
            double euroExchangeRate, 
            double dollarExchangeRate,
            double rublExchangeRate)
        {
            switch (spare.Currency.Code)
            {
                case (int)Currencies.UAH:
                    return 0;
                case (int)Currencies.EUR:
                    return euroExchangeRate;
                case (int)Currencies.USD:
                    return dollarExchangeRate;
                case (int)Currencies.RUB:
                    return rublExchangeRate;
                default:
                    return -1;
            }
}
    }
}