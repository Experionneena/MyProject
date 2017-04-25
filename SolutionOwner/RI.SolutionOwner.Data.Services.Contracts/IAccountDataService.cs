using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    public interface IAccountDataService : IDataService
    {
        IUser CreateUser(IUser user);

        void CreateUsers();

        Task<IEnumerable<IUser>> GetAllUser();

        Task<IUser> GetUserById(int id);

        bool UpdateUser(IUser user);

        bool DeleteUser(IUser user);
    }
}
