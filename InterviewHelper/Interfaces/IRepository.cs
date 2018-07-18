using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Interfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);
        bool Add(TEntity entity);
        bool AddRange(List<TEntity> entities);
        bool Remove(TEntity entity);
        bool RemoveRange(List<TEntity> entities);
    }
}
