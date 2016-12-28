using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Implementations
{
    public class ManufactureRepository : BaseRepository<Manufacturer>, IManufactureRepository
    {
        public Manufacturer FindManufacturer(string manufacturer)
        {
            try
            {
              //  String.Compare("first", "second", true);
                return ContextDb.Manufacturers.FirstOrDefault(x => x.Name.ToLower().Trim() == manufacturer.ToLower().Trim());
            }
            catch (Exception)
            {      
                throw;
            }          
        }

        
       
        
    }

    
}
