using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.BulkInsert.Extensions;
using System.Data.Entity.Infrastructure;

using System.Linq.Expressions;

namespace DAO.Common
{
    public abstract class GenericRepository<T, TK> : IGenericRepository<T, TK>
        where T : Entity<TK>
        where TK : IComparable<TK>
    {
        protected DbContext _entities;

        protected readonly DbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable();
        }


        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return GetAll(predicate);
        }

        public T Add(T entity)
        {
            return _dbset.Add(entity);
        }




        public T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public void Edit(T entity)
        {
            //var state = _entities.Entry(entity).State;

            //if (state == EntityState.Modified)
            //{
            //    state = EntityState.Added;
            //    state = EntityState.Modified;
            //}
            _entities.Entry(entity).State = EntityState.Modified;

        }

        public T GetById(TK id)
        {
            return _dbset.SingleOrDefault(x => x.id.CompareTo(id) == 0);
        }


        public void RunTransaction(Action action, string tblToLock = "")
        {
            using (var dbContextTransaction = _entities.Database.BeginTransaction())
            {
                try
                {
                    if (!String.IsNullOrWhiteSpace(tblToLock))
                    {
                        //Lock the table during this transaction
                        _entities.Database.ExecuteSqlCommand(
                            String.Format("SELECT TOP 0 NULL FROM {0} WITH (TABLOCKX)", tblToLock));
                    }
                    action();

                    dbContextTransaction.Commit();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }

        public void AddRange(IList<T> data)
        {
            _dbset.AddRange(data);
        }

        public void AddBulk(IList<T> data)
        {

            _entities.BulkInsert(data);

        }

        public void CreateBulk(IList<T> data)
        {

            _entities.BulkInsert(data);


        }

        public void RemoveBulk(IList<T> data)
        {
            _dbset.RemoveRange(data);

        }

        public void DeleteBulk(IList<T> data)
        {

            _dbset.RemoveRange(data);

        }

        public void Detach(T entity)
        {
            _entities.Entry(entity).State = EntityState.Detached;
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Any(predicate);
        }

        public IEnumerable<DbEntityEntry> TrackedEntries
        {
            get
            {
                return this._entities.ChangeTracker.Entries();
            }
        }

       

    }
}
