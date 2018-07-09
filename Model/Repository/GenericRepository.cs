using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal QuoteContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(QuoteContext _context)
        {
            this._context = _context;
            this._dbSet = _context.Set<TEntity>();
        }

        #region Methods
        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;
            return query;
        }

        public virtual IQueryable<TEntity> GetAllByFilters(Expression<Func<TEntity, bool>> where, params string[] include)
        {
            IQueryable<TEntity> query = this._dbSet;
            if (include != null)
                query = include.Aggregate(query, (current, inc) => current.Include(inc));
            if (where != null)
                query = query.Where(where);
            return query;
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        #endregion
    }
}
