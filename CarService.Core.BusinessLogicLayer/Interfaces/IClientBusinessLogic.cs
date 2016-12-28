using System;
using System.Collections.Generic;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// interface to be implemented by ClientBusinessLogic
    /// </summary>
    public interface IClientBusinessLogic : IBaseBusinessLogic<Client>
    {
        // method to add new client to the DB
        bool AddNewClient(Client client);

        // method to get all cars by user from the DB
        List<Car> GetClientCars(Guid clientId);
    }
}