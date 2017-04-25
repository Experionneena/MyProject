//------------------------------------------------------
// <copyright file="PrintTemplateMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//--------------------------------------------------------
using System;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// This class maps the print template entity object to and from print template view model
    /// </summary>
    public class PrintTemplateMapper : ObjectMapper<SPPrintTemplateDto, PrintTemplateViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintTemplateMapper"/> class.
        /// </summary>
        /// <param name="provider">service provider</param>
        public PrintTemplateMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// Convert to entity
        /// </summary>
        /// <param name="value">print template view model</param>
        /// <returns>print template entity</returns>
        public override SPPrintTemplateDto ToEntity(PrintTemplateViewModel value)
        {
            var templateEntity = CreateEntity();
            templateEntity.Id = value.Id;
            templateEntity.Name = value.Name;
            templateEntity.PrintText = value.PrintText;
            templateEntity.MerchantCopy = value.MerchantCopy;
            templateEntity.IsActive = value.IsActive;
            return templateEntity;
        }

        /// <summary>
        /// Convert to view model
        /// </summary>
        /// <param name="entity">print template entity</param>
        /// <returns>print template view model</returns>
        public override PrintTemplateViewModel ToObject(SPPrintTemplateDto entity)
        {
            PrintTemplateViewModel model = new PrintTemplateViewModel();
            if (entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.PrintText = entity.PrintText;
                model.MerchantCopy = entity.MerchantCopy;
                model.IsActive = entity.IsActive;
                model.CreatedDate= entity.CreatedDate.Value;
            }

            return model;
        }
    }
}