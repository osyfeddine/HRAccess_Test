using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;


namespace DAO.Common
{

    public interface IGenericRepository<T, TKey>
        where T : Entity<TKey>
        where TKey : IComparable<TKey>
    {

        IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        //void Save();
        T GetById(TKey id);
        void RunTransaction(Action action, string tblToLock = "");
        void AddBulk(IList<T> data);
        void AddRange(IList<T> data);
        void RemoveBulk(IList<T> data);
        void CreateBulk(IList<T> data);
        void DeleteBulk(IList<T> data);
        IEnumerable<DbEntityEntry> TrackedEntries { get; }
        void Detach(T entity);
        bool Any(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

    }
}
