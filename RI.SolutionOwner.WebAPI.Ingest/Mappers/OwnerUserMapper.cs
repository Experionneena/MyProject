using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Dto;
using System;
using System.Collections.Generic;

namespace RI.SolutionOwner.WebAPI.Ingest.Mappers
{
    public class OwnerUserMapper : RI.SolutionOwner.Mapper.ObjectMapper<ISOUser, SOUserDto>
    {
        public OwnerUserMapper(IServiceProvider provider) : base(provider)
        {

        }

        public override ISOUser ToEntity(SOUserDto model)
        {
            var entity = CreateEntity();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Email = model.Email;
            entity.LastLoginDate = model.LastLoginDate;
            entity.IsActive = model.IsActive;
            //entity.IsBlocked = model.IsBlocked;
            //entity.RoleIdList = model.RoleIdList;
            entity.CreatedDate = model.CreatedDate;
            entity.EditedDate = model.EditedDate;
            return entity;
        }

        public override SOUserDto ToObject(ISOUser entity)
        {
            var model = new SOUserDto();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Email = entity.Email;
            model.LastLoginDate = entity.LastLoginDate;
            model.IsActive = entity.IsActive;
            model.RoleNameList = entity.RoleNameList as List<string>;
            model.IsBlocked = entity.IsBlocked;
            //model.CreatedDate = entity.CreatedDate;
            //model.EditedDate = entity.EditedDate;
            return model;
        }
    }
}