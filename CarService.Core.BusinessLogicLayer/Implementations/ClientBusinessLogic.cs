using System;
using System.Collections.Generic;
using CarService.Core.BusinessLogicLayer.Interfaces;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer.Implementations
{
    /// <summary>
    /// Business logic to work with clients
    /// </summary>
    public class ClientBusinessLogic : BaseBusinessLogic<IClientRepository, Client>, IClientBusinessLogic
    {
        public ClientBusinessLogic(IClientRepository repository) : base(repository)
        {
        }

        // method which adds new client to the DB
        public new bool Insert(Client client)
        {
            if (client.IsValidClient())
            {
                Repository.Insert(client);
                return true;
            }
            return false;
        }

        // method to get client's cars from the DB
        public bool AddNewClient(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetClientCars(Guid clientId)
        {
            return Repository.GetClientCars(clientId);
        }
    }
}