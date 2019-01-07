using DAO.Common;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Abstract
{
    public interface IAgentRepository : IGenericRepository<Agent, int>
    {
    }
}
