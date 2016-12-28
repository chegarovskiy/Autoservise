using CarService.Core.DataAccessLayer;
using CarService.Core.DataAccessLayer.Repositories;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Interface to be implemented by UserBusinessLogic
    /// </summary>
    public interface IUserBusinessLogic : IBaseBusinessLogic<User>
    {
         
    }
}