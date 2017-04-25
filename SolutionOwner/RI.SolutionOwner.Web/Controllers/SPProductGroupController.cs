//---------------------------------------------------------
// <copyright file="SPProductGroupController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Controllers
{
    /// <summary>
    /// The Solution partner Product group controller.
    /// </summary>
    public class SPProductGroupController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The product group mapper.
        /// </summary>
        private ObjectMapper<SPProductGroupDto, SPProductGroupViewModel> productGroupMapper = null;

        /// <summary>
        /// The logger.
        /// </summary>
        private ILoggerExtension logger;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPProductGroupController"/> class.
        /// </summary>
        /// <param name="productGroupMapper">The product group mapper.</param>
        /// <param name="logger">The logger.</param>
        public SPProductGroupController(ObjectMapper<SPProductGroupDto, SPProductGroupViewModel> productGroupMapper, ILoggerExtension logger)
        {
            this.productGroupMapper = productGroupMapper;
            this.logger = logger;
        }

        #endregion

        #region Public Methods / Actions

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The Index action.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets the product group list.
        /// </summary>
        /// <returns>The ActionResult</returns>
        public async Task<ActionResult> GetProductGroupList()
        {
            try
            {
                var productGroupList = await GetAllProductGroups();
                var serviceProviderList = await GetServiceProviderSelectList();
                productGroupList.ForEach(
                        x => x.ServiceProviderName = serviceProviderList
                            .Where(y => y.Value == x.ServiceProviderId.ToString())
                            .Select(y => y.Text)
                            .FirstOrDefault());
                return Json(
                    new
                    {
                        Status = 1,
                        Data = RenderRazorViewToString("_ProductGroupList", productGroupList),
                        Message = string.Empty
                    },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Loads the add pop up.
        /// </summary>
        /// <returns>The Action.</returns>
        public async Task<ActionResult> LoadAddPopUp()
        {
            try
            {
                SPProductGroupViewModel productGroupViewModel = new Models.SPProductGroupViewModel();
                productGroupViewModel.ServiceProvidetList = await GetServiceProviderSelectList();

                return Json(new
                {
                    Status = 1,
                    Data = RenderRazorViewToString("_AddPopUp", productGroupViewModel),
                    Message = string.Empty
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Creates the product group.
        /// </summary>
        /// <param name="productGroupViewModel">The pg view model.</param>
        /// <returns>The Action.</returns>
        public async Task<ActionResult> CreateProductGroup(SPProductGroupViewModel productGroupViewModel)
        {
            try
            {
                var produtGroupEntity = productGroupMapper.ToEntity(productGroupViewModel);
                var response = await Post("SPProductGroup/CreateProductGroup", produtGroupEntity);

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
                else if (response.StatusCode == HttpStatusCode.Created)
                {
                    var productGroupList = await GetAllProductGroups();
                    var serviceProviderList = await GetServiceProviderSelectList();
                    productGroupList.ForEach(
                            x => x.ServiceProviderName = serviceProviderList
                                .Where(y => y.Value == x.ServiceProviderId.ToString())
                                .Select(y => y.Text)
                                .FirstOrDefault());
                    return Json(
                        new
                        {
                            Status = 1,
                            Data = RenderRazorViewToString("_ProductGroupList", productGroupList),
                            Message = response.ReasonPhrase
                        });
                }

                return Json(new { Status = 0, Message = response.ReasonPhrase });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Loads the edit pop up.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Action.</returns>
        public async Task<ActionResult> LoadEditPopUp(int id)
        {
            try
            {
                var productGroupViewModel = new SPProductGroupViewModel();
                var responseProductGroup = await Get("SPProductGroup/GetProductGroupById/" + id);
                var serviceProviders = await GetServiceProviderSelectList();
                if (responseProductGroup.IsSuccessStatusCode)
                {
                    var productGroup = await responseProductGroup.Content.ReadAsAsync<SPProductGroupDto>();
                    productGroupViewModel = productGroupMapper.ToObject(productGroup);
                    productGroupViewModel.ServiceProvidetList = serviceProviders;
                }

                return Json(
                    new
                    {
                        Status = 1,
                        Data = RenderRazorViewToString("_EditPopUp", productGroupViewModel)
                    });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Edits the product group.
        /// </summary>
        /// <param name="productGroupVM">The pg view model.</param>
        /// <returns>The Action.</returns>
        public async Task<ActionResult> EditProductGroup(SPProductGroupViewModel productGroupVM)
        {
            try
            {
                var productGroupEntity = productGroupMapper.ToEntity(productGroupVM);
                var response = await Put("SPProductGroup/EditProductGroup", productGroupEntity);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
                else if (response.StatusCode == HttpStatusCode.Created)
                {
                    var productGroupList = await GetAllProductGroups();
                    var serviceProviderList = await GetServiceProviderSelectList();
                    productGroupList.ForEach(
                            x => x.ServiceProviderName = serviceProviderList
                                .Where(y => y.Value == x.ServiceProviderId.ToString())
                                .Select(y => y.Text)
                                .FirstOrDefault());

                    return Json(
                        new
                        {
                            Status = 1,
                            Data = RenderRazorViewToString("_ProductGroupList", productGroupList),
                            Message = response.ReasonPhrase
                        });
                }

                return Json(new { Status = 0, Message = response.ReasonPhrase });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Changes the product group status.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="activeStatus">The active status.</param>
        /// <returns>The Action.</returns>
        public async Task<ActionResult> ChangeProductGroupStatus(int id, int activeStatus)
        {
            try
            {
                var response = await Delete("SPProductGroup/ChangeActiveStatus/" + id + "/" + activeStatus);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    var productGroupList = await GetAllProductGroups();
                    var serviceProviderList = await GetServiceProviderSelectList();
                    productGroupList.ForEach(
                            x => x.ServiceProviderName = serviceProviderList
                                .Where(y => y.Value == x.ServiceProviderId.ToString())
                                .Select(y => y.Text)
                                .FirstOrDefault());
                    return Json(
                        new
                        {
                            Status = 1,
                            Data = RenderRazorViewToString("_ProductGroupList", productGroupList),
                            Message = response.ReasonPhrase
                        });
                }

                return Json(new { Status = 0, Message = response.ReasonPhrase });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the product group.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Action.</returns>
        public async Task<ActionResult> DeleteProductGroup(int id)
        {
            try
            {
                var response = await Delete("SPProductGroup/DeleteProductGroup/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    var productGroupList = await GetAllProductGroups();
                    var serviceProviderList = await GetServiceProviderSelectList();
                    productGroupList.ForEach(
                            x => x.ServiceProviderName = serviceProviderList
                                .Where(y => y.Value == x.ServiceProviderId.ToString())
                                .Select(y => y.Text)
                                .FirstOrDefault());
                    return Json(
                        new
                        {
                            Status = 1,
                            Data = RenderRazorViewToString("_ProductGroupList", productGroupList),
                            Message = response.ReasonPhrase
                        });
                }

                return Json(new { Status = 0, Message = response.ReasonPhrase });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets all product groups.
        /// </summary>
        /// <returns>The List of Product Group</returns>
        private async Task<List<SPProductGroupViewModel>> GetAllProductGroups()
        {
            var productGroupViewModel = new List<SPProductGroupViewModel>();
            var responsePG = await Get("SPProductGroup/GetAllProductGroups");

            if (responsePG.IsSuccessStatusCode)
            {
                var productGroups = await responsePG.Content.ReadAsAsync<List<SPProductGroupDto>>();
                productGroupViewModel = productGroupMapper.ToObjects(productGroups)
                    .OrderByDescending(x => x.CreatedDate)
                    .ToList();
            }

            return productGroupViewModel;
        }

        /// <summary>
        /// Gets the service provider select list.
        /// </summary>
        /// <param name="assignedServiceProviderId">The assigned service provider identifier.</param>
        /// <returns>List of SelectListItem</returns>
        private async Task<List<SelectListItem>> GetServiceProviderSelectList(int assignedServiceProviderId = 0)
        {
            var serviceProviderList = new List<SelectListItem>();
            ////var responsePG = await Get("api/SPProductGroup/GetServiceProviders");
            var responsePG = await Get("SPServiceProvider/GetAllServiceProviders");

            if (responsePG.IsSuccessStatusCode)
            {
                var providers = await responsePG.Content.ReadAsAsync<List<SPServiceProviderDto>>();
                serviceProviderList = providers
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                        Selected = (assignedServiceProviderId != x.Id) ? false : true
                    })
                    .OrderBy(x => x.Text)
                    .ToList();
            }

            return serviceProviderList;
        }

        #endregion
    }
}