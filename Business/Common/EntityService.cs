using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Web;

using System.Data.Entity;
using log4net;
using System.Linq.Expressions;
using System.Reflection;
using System.IO;
using System.Threading;
using DAO.Common;
using Entities.Common;

namespace Business.Common
{
    public abstract class EntityService<T, TKey> : IEntityService<T, TKey>
        where T : Entity<TKey>, new()
        where TKey : IComparable<TKey>
    {
        IUnitOfWork _unitOfWork;
        protected IGenericRepository<T, TKey> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T, TKey> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            this.Commit();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Edit(entity);
            this.Commit();
        }

        public void Edit(T entity)
        {
            _repository.Edit(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            this.Commit();
        }
        public virtual IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            return _repository.GetAll(predicate);
        }

        public IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] entities)
        {
            return _repository.GetAll().IncludeMultiple(entities);
        }

        public IEnumerable<T> GetAllIncluding(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] entities)
        {
            return _repository.GetAll(predicate).IncludeMultiple(entities);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }


        public T GetById(TKey Id)
        {
            return _repository.GetById(Id);
        }

        public virtual IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _repository.GetAll(predicate);
        }


        public void RunTransaction(Action action, string tblToLock = "")
        {
            _repository.RunTransaction(action, tblToLock);
        }

        public void Commit()
        {
            this.Committing();
            _unitOfWork.Commit();

        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Remove(T entity)
        {
            _repository.Delete(entity);
        }

        public void AddBulk(IList<T> entities)
        {
            _repository.AddBulk(entities);
        }
        public void RemoveBulk(IList<T> entities)
        {
            _repository.RemoveBulk(entities);
        }

       

        protected virtual void Committing()
        {
            try
            {
                int userId = 0;

                if (System.Web.HttpContext.Current != null)
                {
                    var sessionUserId = System.Web.HttpContext.Current.Session["UserId"];

                    if (sessionUserId != null)
                    {
                        userId = (int)sessionUserId;

                        var modifiedEntries = this._repository.TrackedEntries
                                   .Where(x => x.Entity is IAuditableEntity
                                       &&
                                         (x.State == System.Data.Entity.EntityState.Added
                                        || x.State == System.Data.Entity.EntityState.Modified
                                        ));

                        foreach (var entry in modifiedEntries)
                        {
                            IAuditableEntity entity = entry.Entity as IAuditableEntity;

                            if (entity != null)
                            {
                                DateTime now = DateTime.UtcNow;

                                if (entry.State == System.Data.Entity.EntityState.Added)
                                {
                                    entity.CreatedBy = userId;
                                    entity.CreationDate = now;
                                }
                                else
                                {
                                    entity.ModifiedBy = userId;
                                    entity.ModificationDate = now;

                                }

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

                log.Info(String.Format("Exception occured while updating history of IAuditableEntity {0}\n {1}",
                    typeof(T).Name, ex.ToString()));
             
            }
        }

        public void Detach(T entity)
        {
            _repository.Detach(entity);
        }

        public bool Any(Expression<Func<T, bool>> predicate) => _repository.Any(predicate);
    }
}
