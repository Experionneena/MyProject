using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    public interface IAgent : IEntity
    {
        string Name { get; set; }

        string Address { get; set; }
    }
}
