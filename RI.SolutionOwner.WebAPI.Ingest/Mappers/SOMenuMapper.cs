using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.WebAPI.Ingest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.WebAPI.Ingest.Mappers
{
    public class SOMenuMapper : ObjectMapper<ISOMenu, SOMenuModel>
    {
        public SOMenuMapper(IServiceProvider services) : base(services)
        {
        }

        public override ISOMenu ToEntity(SOMenuModel value)
        {
            var entity = CreateEntity();

            entity.Id = (int)value.Id;
            entity.IsActive = value.IsActive;
            ////entity.CreatedDate = value.CreatedDate;
            entity.Description = value.Description;
            //////entity.EditedDate = value.EditedDate;
            entity.FeatureId = value.FeatureId;
            entity.Icon = value.MenuIcon;
            entity.Name = value.MenuName;
            entity.ParentMenuId = value.ParentMenuId;
            entity.SortOrder = value.SortOrder;
            return entity;
        }

        public override SOMenuModel ToObject(ISOMenu entity)
        {
            var value = new SOMenuModel();
            value.Id = (int)entity.Id;
            value.IsActive = entity.IsActive;
            ////value.CreatedDate = entity.CreatedDate;
            value.Description = entity.Description;
            ////value.EditedDate = entity.EditedDate;
            value.FeatureId = entity.FeatureId;
            value.MenuIcon = entity.Icon;
            value.MenuName = entity.Name;
            value.ParentMenuId = entity.ParentMenuId;
            value.SortOrder = entity.SortOrder;
            return value;
        }
    }
}