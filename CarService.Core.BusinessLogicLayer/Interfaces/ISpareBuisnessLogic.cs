using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    public interface ISpareBuisnessLogic : IBaseBusinessLogic<Spare>
    {
        Spare FindSpare(string spare);
    }
}