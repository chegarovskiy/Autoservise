using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    public class CurrenceBusinessLogic : BaseBusinessLogic<ICurrencyRepository, Currency>, ICurrencyBusinessLogic
    {
        private readonly ICurrencyRepository _repository;

        public CurrenceBusinessLogic(ICurrencyRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Currency FindCurrensy(string currensy)
        {
            return _repository.FindCurrensy(currensy);
        }
    }
}