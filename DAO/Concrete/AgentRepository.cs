using DAO.Abstract;
using DAO.Common;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Concrete
{
    public class AgentRepository: GenericRepository<Agent, int>, IAgentRepository
    {
        public AgentRepository(SyfoContext context)
                    : base(context)
        {

        }
    }
}
