using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Interfaces
{
    public interface ISpareRepository : IBaseRepository<Spare>
    {
        Spare FindSpare(string spare);

        Currency AddCurrency(string name);
        Manufacturer AddManufacturer(string name);

    }
}