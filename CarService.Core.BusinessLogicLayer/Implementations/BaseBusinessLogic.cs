using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using CarService.Core.DataAccessLayer;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Base business logic class
    /// to be base one for all other business logic classes
    /// Implements IBaseBusinessLogic class
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseBusinessLogic<TRepository, TEntity> : IBaseBusinessLogic<TEntity>
    where TEntity : ModelId, IEntity
    where TRepository : class, IBaseRepository<TEntity>
    {
        // repository for working with particular business logic
        protected TRepository Repository { get; set; }

        // constructor which takes particular repository as a parameter
        public BaseBusinessLogic(TRepository repository)
        {
            Repository = repository;
        }

        // get by predicate
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.Get(predicate);
        }

        // get all entities of a TEntity type
        public virtual IQueryable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        // get entity by Id
        public TEntity GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        // rempve particular entity
        public virtual void Remove(TEntity entity)
        {
            Repository.Remove(entity);
        }

        // update an entity
        public virtual void Update(TEntity entity)
        {
            Repository.Update(entity);
        }

        // insert new entity
        public virtual void Insert(TEntity entity)
        {
            Repository.Insert(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entity)
        {
            Repository.InsertRange(entity);
        }

        public virtual void SaveChanges()
        {
            Repository.SaveChanges();
        }
    }
}