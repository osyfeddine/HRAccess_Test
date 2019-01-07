
using DAO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Entities.Common
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity where T : IComparable<T>
    {
        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

      
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public int CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime ModificationDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public int ModifiedBy { get; set; }
    }
}
