using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Implementations
{
    public class SpareRepository : BaseRepository<Spare>, ISpareRepository
    {
        public Spare FindSpare(string spare)
        {
            return ContextDb.Spares.FirstOrDefault(x => x.Code.ToString().ToLower().Trim() == spare.ToLower().Trim());
        }

        public Currency AddCurrency(string name)
        {
            return ContextDb.Currencies.FirstOrDefault(x => x.Name.Equals(name));
        }

        public Manufacturer AddManufacturer(string name)
        {
            return ContextDb.Manufacturers.FirstOrDefault(x => x.Name.Equals(name));
        }

    }

}
