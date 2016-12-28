using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Interfaces
{
    public interface IManufactureRepository : IBaseRepository<Manufacturer>
    {
        Manufacturer FindManufacturer(string manufacturer);
    }
}