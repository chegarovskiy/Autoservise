using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Repositories.Interfaces
{
    /// <summary>
    /// IBase repository for CRUD operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : ModelId, IEntity
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Remove(TEntity entity);
        void SaveChanges();
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entity);
    }
}