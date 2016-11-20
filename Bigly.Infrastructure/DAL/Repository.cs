using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using Bigly.Infrastructure.DomainBase;

namespace Bigly.Infrastructure
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>, IDisposable
        where TEntity : Entity, IAggregateRoot where TContext:DbContext
    {
      
        protected readonly IUnitOfWork<TContext> _unitOfWork;
        protected IDbSet<TEntity> _dbSet => _context.Set<TEntity>();
        private readonly TContext _context;

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
            AddAndAttach(entity);
           return CommitChanges();
        }

        public virtual bool BatchInsert(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                return false;

            foreach (TEntity entity in entities)
            {
                AddAndAttach(entity);
            }

            return CommitChanges();
        }

        public virtual bool BatchUpdate(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                return false;

            foreach (TEntity entity in entities)
            {
                ModifyAndAttach(entity);
            }
            
            return CommitChanges();
        }

        public virtual bool Update(TEntity entity)
        {
            ModifyAndAttach(entity);
            return _unitOfWork.Save();
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
            return _unitOfWork.Save();
        }

        private void ModifyAndAttach(TEntity entity)
        {
            entity.State = State.Modified;

            var entry = _context.Entry<TEntity>(entity);

            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
        }

        private void AddAndAttach(TEntity entity)
        {
            entity.State = State.Added;

            var entry = _context.Entry<TEntity>(entity);

            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if(_context!=null)
                    _context.Dispose();
                    if(_unitOfWork!=null)
                    _unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
