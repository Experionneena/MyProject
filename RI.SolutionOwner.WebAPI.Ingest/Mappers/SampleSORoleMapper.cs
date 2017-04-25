using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Dto;
using RI.SolutionOwner.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.WebAPI.Ingest.Mappers
{
    public class SampleSORoleMapper : ObjectMapper<ISORole, SampleSORoleDto>
    {
        public SampleSORoleMapper(IServiceProvider services) : base(services)
        {
        }

        public override ISORole ToEntity(SampleSORoleDto value)
        {
            var entity = CreateEntity();

            entity.Id = value.Id;
            entity.RoleName = value.RoleName;
            entity.Description = value.Description;
            entity.ActiveStatus = value.IsActive;
            //entity.CreatedDate = value.CreatedDate;
            //entity.EditedDate = value.EditedDate;
            return entity;
        }

        public override SampleSORoleDto ToObject(ISORole entity)
        {
            var value = new SampleSORoleDto();

            value.Id = entity.Id;
            value.RoleName = entity.RoleName;
            value.Description = entity.Description;
            value.IsActive = entity.ActiveStatus;
            //value.CreatedDate = entity.CreatedDate;
            //value.EditedDate = entity.EditedDate;
            return value;
        }
    }
}