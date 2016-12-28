using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories
{
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
    {
        public Currency FindCurrensy(string currensy)
        {
            try
            {
                return ContextDb.Currencies.FirstOrDefault(x => x.Name.ToLower().Trim() == currensy.ToLower().Trim());     
            }
            catch (Exception)
            {
                throw;
            }
        }
        // пока не используем, если надо будет, добавим
        public void AddCurrensy(string currensy)
        {
            try
            {
                Currency newCurrency = new Currency();
                newCurrency.Name = currensy;

                ContextDb.Currencies.Add(newCurrency);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AddIfNotFoundCurrency(string currensy)
        {
            try
            {
                Currency newCurrency = new Currency();  
                if (ContextDb.Currencies.FirstOrDefault(x => x.Name.ToLower().Trim() == currensy.ToLower().Trim()) != null)
                {  
                    newCurrency.Name = currensy;
                    ContextDb.Currencies.Add(newCurrency);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
