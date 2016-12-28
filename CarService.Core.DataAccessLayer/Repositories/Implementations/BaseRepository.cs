using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using CarService.Core.DataAccessLayer.Context;
using CarService.Core.DataAccessLayer.Repositories;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer
{
    /// <summary>
    /// Base repository to perform CRUD operations over DB entities
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : ModelId, IEntity
    {
        //ToDo make context protected
        // declare public DbContext
        protected CarServiceDbContext ContextDb { get; } = new CarServiceDbContext();

        // get by predicate
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return ContextDb.Set<TEntity>().Where(predicate);
        }

        // returns all entities which match predicate
        public virtual IQueryable<TEntity> GetAll()
        {
            return ContextDb.Set<TEntity>();
        }

        // returns found by id entity or null if entity was not found
        public TEntity GetById(Guid id)
        {
            return ContextDb.Set<TEntity>().Find(id);
        }

        // removes an entity from the DB
        public virtual void Remove(TEntity entity)
        {
            ContextDb.Set<TEntity>().Remove(entity);
            ContextDb.SaveChanges();
        }

        // updates an entity in the DB
        public virtual void Update(TEntity entity)
        {
            try
            {
                ContextDb.Entry(entity).State = EntityState.Modified;
                ContextDb.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                            "Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }

                }

            }
        }

        // inserts an entity to the DB
        public virtual void Insert(TEntity entity)
        {
            try
            {
                ContextDb.Set<TEntity>().Add(entity);
                ContextDb.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                            "Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }

                }
            }
            catch (Exception dbEx)
            {
                
            }
        }

        public virtual void InsertRange(IEnumerable<TEntity> entity)
        {
            try
            {
                ContextDb.Set<TEntity>().AddRange(entity);
                ContextDb.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                            "Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }

                }

            }
        }
        public virtual void SaveChanges()
        {
            ContextDb.SaveChanges();
        }
    }
}