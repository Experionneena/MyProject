using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    public class Agent : BaseEntity, IAgent
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}