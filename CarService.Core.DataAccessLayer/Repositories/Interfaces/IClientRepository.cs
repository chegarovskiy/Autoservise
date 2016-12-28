using System;
using System.Collections.Generic;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Interfaces
{
    /// <summary>
    /// To be implemented by ClientRepository
    /// </summary>
    public interface IClientRepository : IBaseRepository<Client>
    {
        // returns all cars of a client or empty list
        List<Car> GetClientCars(Guid clientId);
    }
}