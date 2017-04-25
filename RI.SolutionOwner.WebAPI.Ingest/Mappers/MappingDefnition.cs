using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.WebAPI.Ingest.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.WebAPI.Ingest.Mappers
{
    public class MappingDefnition
    {
        public void Initialize()
        {
            var domainEntities = ReferencedAssemblies.DomainEntities.GetTypes().
                Where(x => typeof(IEntity).IsAssignableFrom(x)).ToList();

            var businessDtos = ReferencedAssemblies.BusinessDto.GetTypes().
                Where(x => typeof(IEntity).IsAssignableFrom(x)).ToList();
        }
    }
}