using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using Bigly.Infrastructure.DomainBase;

namespace Bigly.Infrastructure
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot where TContext:DbContext
    {
        public IContext<TEntity> Dal { get; set; }
        protected readonly IUnitOfWork<TContext> _unitOfWork;
        protected IDbSet<TEntity> _dbSet => _context.Set<TEntity>();
        private readonly DbContext _context;

        public Repository() {}
         
        public Repository(IUnitOfWork<TContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = unitOfWork.Context;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            
            return _dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id == id);
        }

        public virtual bool Insert(TEntity entity)
        {
            entity.State = State.Added;
            _dbSet.Add(entity);
           return CommitChanges();
        }

        public virtual bool Update(TEntity entity)
        {
            entity.State = State.Modified;            
            _dbSet.Attach(entity);
            return CommitChanges();
        }

        public bool Delete(TEntity entity)
        {
            entity.State = State.Deleted;
            _dbSet.Remove(entity);
            return CommitChanges();
        }

        public virtual bool DeleteById(int id)
        {
            TEntity entity = _dbSet.FirstOrDefault(e => e.Id == id);
            if (entity == null) throw new ObjectNotFoundException($"Entity with id = {id} not found.");
            entity.State = State.Deleted;
            _dbSet.Remove(entity);

            return CommitChanges();
        }

        private bool CommitChanges()
        {
            return _unitOfWork.Save() > 0;
        }
    }
}
