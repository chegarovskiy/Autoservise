using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer.Implementations
{
        public class ManufactureBusinessLogic : BaseBusinessLogic<IManufactureRepository, Manufacturer>, IManufactureBusinessLogic
        {
            private readonly IManufactureRepository _repository;

            public ManufactureBusinessLogic(IManufactureRepository repository) : base(repository)
            {
                _repository = repository;
            }

            public Manufacturer FindManufacturer(string manufacturer)
            {
                return _repository.FindManufacturer(manufacturer);
            }

        public void InsertRange(List<Spare> sparesList)
        {
            throw new NotImplementedException();
        }
    }
    
}