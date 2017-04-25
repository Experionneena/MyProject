using RI.Framework.Core.Data.Entities;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    public interface IAgentDataService : IDataService
    {
        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <param name="agent">The agent.</param>
        /// <returns></returns>
        IAgent CreateAgent(IAgent agent);
    }
}
