using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.WebAPI.Ingest.Models;
using System;

namespace RI.SolutionOwner.WebAPI.Ingest.Mappers
{
    public class RoleMapper : ObjectMapper<IRole, RoleModel>
    {
        public RoleMapper(IServiceProvider provider) : base(provider)
        {

        }

        public override IRole ToEntity(RoleModel value)
        {
            var roleEntity = CreateEntity();
            //userEntity.Settings = (IUserSettings)Services.GetService(typeof(IUserSettings));
            roleEntity.Id = value.Id;
            roleEntity.RoleName = value.RoleName;
            roleEntity.Description = value.Description;
            roleEntity.ActiveStatus = value.ActiveStatus;
            return roleEntity;
        }

        public override RoleModel ToObject(IRole entity)
        {
            var model = new RoleModel();
            model.Id = entity.Id;
            model.RoleName = entity.RoleName;
            model.Description = entity.Description;
            model.ActiveStatus = entity.ActiveStatus;
            return model;
        }
    }
}