using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    public interface IManufactureBusinessLogic : IBaseBusinessLogic<Manufacturer>
    {
        Manufacturer FindManufacturer(string manufacturer);
    }
}