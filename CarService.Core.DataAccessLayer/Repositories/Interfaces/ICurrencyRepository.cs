using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Interfaces
{
    public interface ICurrencyRepository : IBaseRepository<Currency>
    {
        Currency FindCurrensy(string currensy);
    }
}