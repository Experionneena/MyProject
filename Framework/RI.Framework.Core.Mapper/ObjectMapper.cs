﻿using RI.Framework.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Mapper
{
    public abstract class ObjectMapper<TEntity, TObject>
  where TEntity : class, new()
  where TObject : class, new()
    {
        protected IServiceProvider Services { get; set; }

        protected ObjectMapper(IServiceProvider services)
        {
            Services = services;
        }

        public abstract TObject ToObject(TEntity entity);
        public abstract TEntity ToEntity(TObject value);

        protected TEntity CreateEntity()
        {
            var entity = (TEntity)Services.GetService(typeof(TEntity));
            return entity;
        }

        public IEnumerable<TObject> ToObjects(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                yield return ToObject(entity);
            }
        }

        public IEnumerable<TEntity> ToEntities(IEnumerable<TObject> items)
        {
            foreach (var item in items)
            {
                yield return ToEntity(item);
            }
        }
    }
}
