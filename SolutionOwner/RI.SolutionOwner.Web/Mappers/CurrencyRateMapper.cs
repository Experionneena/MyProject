// ---------------------------------------------------------
// <copyright file="CurrencyRateMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// Class Currency Rate Mapper
    /// </summary>
    public class CurrencyRateMapper : Mapper.ObjectMapper<SPCurrencyRateDto, CurrencyRateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRateMapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public CurrencyRateMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Interface ISPCurrencyRate</returns>
        public override SPCurrencyRateDto ToEntity(CurrencyRateModel model)
        {
            var entity = CreateEntity();
            entity.Id = model.Id;
            entity.CurrencyDescription = model.CurrencyDescription;
            entity.CurrencyId = model.CurrencyId;
            entity.IsActive = model.IsActive;
            entity.Rate = model.Rate;
            return entity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Model CurrencyRateModel</returns>
        public override CurrencyRateModel ToObject(SPCurrencyRateDto entity)
        {
            var model = new CurrencyRateModel();
            model.Id = entity.Id;
            model.CurrencyDescription = entity.CurrencyDescription;
            model.CurrencyId = entity.CurrencyId;
            model.IsActive = entity.IsActive;
            model.Rate = entity.Rate;
            model.CurrencyNameList = entity.CurrencyList as List<string>;
            return model;
        }
    }
}