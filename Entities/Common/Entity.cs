using Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Common
{

    public abstract class Entity<T> : IEntity<T> where T : IComparable<T>
    {
        public virtual T id { get; set; }

    }
}
