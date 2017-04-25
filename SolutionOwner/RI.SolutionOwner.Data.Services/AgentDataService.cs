using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    public class AgentDataService : BaseDataService, IAgentDataService
    {
        public AgentDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IAgent CreateAgent(IAgent agent)
        {
            var repository = UnitOfWork.Repository<IAgent>();
            repository.Add(agent);
            UnitOfWork.Commit();
            return agent;
        }
    }
}
