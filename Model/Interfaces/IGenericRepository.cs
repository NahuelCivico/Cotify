using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        #region GetAll Action
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllByFilters(Expression<Func<TEntity, bool>> where, params string[] include);
        #endregion

        #region Create Action
        void Insert(TEntity entity);
        #endregion
    }
}
