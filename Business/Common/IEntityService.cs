using DAO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Business.Common
{
    public interface IEntityService<T, TKey> 
        where T : Entity<TKey>
        where TKey : IComparable<TKey>
    {
        void Add(T entity);
        void Remove(T entity);
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] entities);
        IEnumerable<T> GetAllIncluding(System.Linq.Expressions.Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] entities);
        void Update(T entity);
        IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        T GetById(TKey Id);

        void RunTransaction(Action action, string tblToLock = null);

        void Commit();
        void Edit(T entity);


        void AddBulk(IList<T> entities);
        void RemoveBulk(IList<T> entities);
        void Detach(T entity);

        bool Any(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

       
    }
}
