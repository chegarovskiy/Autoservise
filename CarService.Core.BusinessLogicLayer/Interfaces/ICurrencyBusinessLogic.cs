using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    public interface ICurrencyBusinessLogic : IBaseBusinessLogic<Currency>
    {
        Currency FindCurrensy(string currensy);
    }
}