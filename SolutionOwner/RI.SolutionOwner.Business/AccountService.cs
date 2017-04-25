using RI.SolutionOwner.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business
{
    public class AccountService : IAccountService
    {
        private IAccountDataService _accountDataService;
        public AccountService(IAccountDataService accountDataService)
        {
            _accountDataService = accountDataService;
        }
        public IUser CreateUser(IUser user)
        {
            return _accountDataService.CreateUser(user);
        }

        public void CreateUsers()
        {
            _accountDataService.CreateUsers();
        }

        public async Task<IEnumerable<IUser>> GetAllUser()
        {
            return await _accountDataService.GetAllUser();
        }

        public async Task<IUser> GetUserById(int id)
        {
            return await _accountDataService.GetUserById(id);
        }

        public bool UpdateUser(IUser user)
        {
            return _accountDataService.UpdateUser(user);
        }

        public bool DeleteUser(IUser user)
        {
            return _accountDataService.DeleteUser(user);
        }
    }
}
