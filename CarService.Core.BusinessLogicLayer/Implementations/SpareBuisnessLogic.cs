using CarService.Core.DataAccessLayer.Repositories.Implementations;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer.Implementations
{
    public class SpareBuisnessLogic : BaseBusinessLogic<ISpareRepository, Spare>, ISpareBuisnessLogic
    {
       
        private readonly ISpareRepository _repository;

     
        public SpareBuisnessLogic(ISpareRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Spare FindSpare(string spare)
        {
            return _repository.FindSpare(spare);
        }

        public Currency AttachCurrency(string name)
        {
            return Repository.AddCurrency(name);
        }

        public Manufacturer AttachManufacturer(string name)
        {
            return Repository.AddManufacturer(name);
        }
    }
}