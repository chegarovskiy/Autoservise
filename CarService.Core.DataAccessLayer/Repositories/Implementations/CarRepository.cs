using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Implementations
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        // get car brand
        public Client CarOwner(Guid clientId)
        {
            return ContextDb.Client.FirstOrDefault(x => x.Id == clientId);
        }

        // get car model
        public Model CarModel(Guid modelId, Guid brandId)
        {
            return ContextDb.Models.FirstOrDefault(x => x.Id == modelId 
                                                   && x.Brand.Id == brandId);
        }


        // ToDO come back to this method
        // get all cars of a user from the DB
        public List<Car> GetUserCars(Guid clientId)
        {
            return ContextDb.Cars.Where(x => x.Client.Id == clientId)
                .Include(x => x.Client)
                .Include(x => x.Model)
                .Include(x => x.Model.Brand)
                .ToList();
        }
    }
}