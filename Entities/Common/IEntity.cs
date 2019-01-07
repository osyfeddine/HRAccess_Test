using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Common
{
    public interface IEntity<T> 
   {
       T id { get; set; }
   }
}
