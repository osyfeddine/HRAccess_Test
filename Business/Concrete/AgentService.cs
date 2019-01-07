using Business.Abstract;
using Business.Common;
using DAO.Common;
using DAO.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AgentService: EntityService<Agent, int>, IAgentService
    {
        public AgentService(IUnitOfWork unitOfWork,
          AgentRepository agentRepository)
          : base(unitOfWork, agentRepository)
        {
        }
    }
}
