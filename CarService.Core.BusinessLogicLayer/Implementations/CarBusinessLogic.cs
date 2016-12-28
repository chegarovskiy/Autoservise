using System;
using System.Collections.Generic;
using CarService.Core.BusinessLogicLayer.Interfaces;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer.Implementations
{
    /// <summary>
    /// Business logic to work with cars
    /// </summary>
    public class CarBusinessLogic : BaseBusinessLogic<ICarRepository, Car>, ICarBusinessLogic
    {
        public CarBusinessLogic(ICarRepository repository) : base(repository)
        {
        }

        // method to add new car for a client
        public bool AddClientCar(Car car, Guid clientId, Guid brandId, Guid modelId)
        {
            // check text fields of the car entity
            if (!car.IsValidCar())
            {
                return false;
            }

            // get car's model and client from DB
            var model = Repository.CarModel(modelId, brandId);
            var client = Repository.CarOwner(clientId);

            // if they are valid
            if (model == null || client == null)
            {
                return false;
            }
            
            // assign them to the car's properties
            car.Client = client;
            car.Model = model;
            
            Repository.Insert(car);
            return false;
        }

        // get user's cars from the DB
        public List<Car> ClientCars(Guid clientId)
        {
            return Repository.GetUserCars(clientId);
        }
    }
}