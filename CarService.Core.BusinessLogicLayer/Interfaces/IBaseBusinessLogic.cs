using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Base business logic interface 
    /// to be implemented by other business logic interfaces
    /// Assumes that business logic should be able to do basic CRUD operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseBusinessLogic<TEntity>
        where TEntity : ModelId, IEntity
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entity);
        void SaveChanges();
        
    }

    
}