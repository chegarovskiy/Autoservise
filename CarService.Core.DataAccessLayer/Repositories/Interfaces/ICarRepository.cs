using System;
using System.Collections.Generic;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Interfaces
{
    /// <summary>
    /// To be implemented by CarRepository
    /// </summary>
    public interface ICarRepository : IBaseRepository<Car>
    {
        // get car owner from DB
        Client CarOwner(Guid clientId);
        // get car model from DB
        Model CarModel(Guid modelId, Guid brandId);

        // get all cars of a user from the DB
        List<Car> GetUserCars(Guid clientId);
    }
}