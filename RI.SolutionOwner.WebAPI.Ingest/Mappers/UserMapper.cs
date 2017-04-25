using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.WebAPI.Ingest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.WebAPI.Ingest.Mappers
{
    public class UserMapper : ObjectMapper<IUser, UserModel>
    {
        public UserMapper(IServiceProvider provider) : base(provider)
        {

        }

        public override IUser ToEntity(UserModel value)
        {
            var userEntity = CreateEntity();
            userEntity.Id = value.Id;
            userEntity.Password = value.Password;
            userEntity.UserName = value.UserName;
            return userEntity;
        }

        public override UserModel ToObject(IUser entity)
        {
            var model = new UserModel();
            model.Id = entity.Id;
            model.Password = entity.Password;
            model.UserName = entity.UserName;
            return model;
        }
    }
}