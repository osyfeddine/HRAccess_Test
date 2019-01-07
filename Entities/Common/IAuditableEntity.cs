using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace Entities.Common
{
    public interface IAuditableEntity 
    {
        DateTime CreationDate { get; set; }
     
        int CreatedBy { get; set; }

        DateTime ModificationDate { get; set; }
             
        int ModifiedBy { get; set; }
    }
}
