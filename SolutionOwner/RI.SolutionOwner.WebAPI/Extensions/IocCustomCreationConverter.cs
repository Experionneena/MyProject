using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RI.SolutionOwner.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders.Providers;

namespace RI.SolutionOwner.WebAPI.Extensions
{
    public class IocCustomCreationConverter : IModelBinder
    {
        readonly JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

        public class ServiceEntityConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                var scalarType =
                    GetServiceLocator.Instance.GetService(objectType)?.GetType();
                if(null != scalarType)
                {
                    return true;
                }

                return false;
            }

            public override object ReadJson(JsonReader reader, 
                Type objectType, 
                object existingValue, 
                JsonSerializer serializer)
            {
                var scalarType =
                    GetServiceLocator.Instance.GetService(objectType)?.GetType();
                if (null != scalarType)
                {
                    return serializer.Deserialize(reader, scalarType);
                }
                else
                {
                    throw new NotImplementedException("Conversion of type " + objectType.FullName + " doesn't exists.");
                }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }


        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var serviceType = GetServiceLocator.Instance.GetService(bindingContext.ModelType).GetType();
            var content = actionContext.Request.Content;
            string json = content.ReadAsStringAsync().Result;
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new ServiceEntityConverter());
            var reader = new JsonTextReader(new StringReader(json));
            var obj = serializer.Deserialize(reader, serviceType);
            bindingContext.Model = obj;
            return true;
        }
    }
}