using System;
using System.Collections.Generic;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// interface to be implemented by CarBusinessLogic
    /// </summary>
    public interface ICarBusinessLogic : IBaseBusinessLogic<Car>
    {
        // method to add new car for a client
        bool AddClientCar(Car car, Guid clientId, Guid brandId, Guid modelId);

        // get cars of a user
        List<Car> ClientCars(Guid clientId);
    }
}