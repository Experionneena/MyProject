using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;
using RI.Framework.Core.Data;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Services
{
    public class AccountDataService : BaseDataService, IAccountDataService
    {
        private IRepository<IUser> _users;
        private IRepository<IUserSettings> _usersSettings;

        public AccountDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _users = UnitOfWork.Repository<IUser>();
            _usersSettings = UnitOfWork.Repository<IUserSettings>();
        }

        public IUser CreateUser(IUser user)
        {
            User _user = new User
            {
                Password = user.Password,
                UserName = user.UserName,
                //Settings = new UserSettings
                //{
                //    IsTwoFactorAuthEnabled = false
                //}
            };

            var savedUser = _users.Add(_user);
            //user.settings.user.id = saveduser.id;
            //_userssettings.add(user.settings);
            //saveduser.settings = user.settings;
            UnitOfWork.Commit();
            return savedUser;
        }

        public void CreateUsers()
        {
            var users = new List<IUser>();
            for (var i = 0; i < 10; i++)
            {
                users.Add(new User
                {
                    Password = "password" + i,
                    UserName = "username" + i
                });
            }

            _users.Insert(users);
            UnitOfWork.Commit();
        }

        public async Task<IEnumerable<IUser>> GetAllUser()
        {
            return await _users.GetAllAsync();
        }

        public async Task<IUser> GetUserById(int id)
        {
            var user = _users.Entities.Where(x => x.Id == id);
            return await _users.GetByIdAsync(id);
        }

        public bool UpdateUser(IUser user)
        {
            _users.Update(user);
            var updatedResult = UnitOfWork.Commit();
            return updatedResult == 1 ? true : false;
        }

        public bool DeleteUser(IUser user)
        {
            ////_usersSettings.Delete(user.Settings);
            ////UnitOfWork.Commit();
            _users.Delete(user);
            var deleteResponse = UnitOfWork.Commit();
            return deleteResponse == 1 ? true : false;
        }
    }
}
