using InterviewHelper.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace InterviewHelper.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected InterviewEF Context;
        public Repository(InterviewEF dbContext)
        {
            this.Context = dbContext;
        }

        public bool Add(TEntity entity)
        {
            if(Context.Set<TEntity>().Add(entity) == null) return false;
            return true;
        }

        public bool AddRange(List<TEntity> entities)
        {
            if (Context.Set<TEntity>().AddRange(entities) == null) return false;
            return true;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where<TEntity>(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList<TEntity>();
        }

        public bool Remove(TEntity entity)
        {
            if (Context.Set<TEntity>().Remove(entity) == null) return false;
            return true;
        }

        public bool RemoveRange(List<TEntity> entities)
        {
            if (Context.Set<TEntity>().RemoveRange(entities) == null) return false;
            return true;
        }


    }
}