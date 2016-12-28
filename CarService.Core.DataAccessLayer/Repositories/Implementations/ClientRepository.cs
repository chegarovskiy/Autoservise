using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Implementations
{
    /// <summary>
    /// Repository to perform CRUD operations with client
    /// </summary>
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public List<Car> GetClientCars(Guid clientId)
        {
            return ContextDb.Cars.Where(x => x.Client.Id == clientId)
                .Include(x => x.Model)
                .Include(x => x.Client)
                .ToList();
        }
    }
}