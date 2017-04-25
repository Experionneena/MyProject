//----------------------------------------------------------
// <copyright file="POSConfigurationController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------

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
    /// This controller has action methods for CRUD operations on POSParameter.
    /// </summary>
    public class POSConfigurationController : BaseController
    {
        #region Private Members
        /// <summary>
        /// The service provider
        /// </summary>
        private IServiceProvider serviceProvider;

        /// <summary>
        /// The pos parameter mapper
        /// </summary>
        private ObjectMapper<POSParameterDto, POSParameterModel> posParameterMapper;

        /// <summary>
        /// The pos parameter category mapper
        /// </summary>
        private ObjectMapper<POSParameterCategoryDto, POSParmeterCategoryModel> posParameterCategoryMapper;

        /// <summary>
        /// The _logger
        /// </summary>
        private ILoggerExtension logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="POSConfigurationController" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="posParameterMapper">The position parameter mapper.</param>
        /// <param name="posParameterCategoryMapper">The position parameter category mapper.</param>
        /// <param name="logger">The logger.</param>
        public POSConfigurationController(
                                  IServiceProvider serviceProvider,
                                  ObjectMapper<POSParameterDto, POSParameterModel> posParameterMapper,
                                  ObjectMapper<POSParameterCategoryDto, POSParmeterCategoryModel> posParameterCategoryMapper,
                                  ILoggerExtension logger)
        {
            this.serviceProvider = serviceProvider;
            this.posParameterMapper = posParameterMapper;
            this.posParameterCategoryMapper = posParameterCategoryMapper;
            this.logger = logger;
        }

        #endregion

        #region  Public Methods / Actions 

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>returns index view.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets the position parameters.
        /// </summary>
        /// <returns>returns pos_List partial view.</returns>
        public async Task<ActionResult> GetPosParameters()
        {
            try
            {
                var posList = await GetAllPosParameters();
                if (posList != null)
                {
                    return Json(new { Status = 1, Data = RenderRazorViewToString("pos_List", posList) });
                }

                return Json(new { Status = 1, Data = RenderRazorViewToString("pos_List", posList) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all position parameters.
        /// </summary>
        /// <returns>returns list of POSParmeterCategoryModel.</returns>
        public async Task<List<POSParmeterCategoryModel>> GetAllPosParameters()
        {
            try
            {
                List<POSParmeterCategoryModel> posParameterCategories = new List<POSParmeterCategoryModel>();
                List<POSParameterModel> posParameters = new List<POSParameterModel>();
                var responseParamCat = await Get("POSParameterCategory/GetAllPOSParameterCategories");
                if (responseParamCat.StatusCode == HttpStatusCode.OK)
                {
                    var posCatList = await responseParamCat.Content.ReadAsAsync<List<POSParameterCategoryDto>>();
                    if (posCatList.Count > 0)
                    {
                        posParameterCategories = posParameterCategoryMapper.ToObjects(posCatList)
                           .ToList();
                        var responseParam = await Get("POS/GetAllPOSParameters");
                        var posList = await responseParam.Content.ReadAsAsync<List<POSParameterDto>>();
                        if (posList.Count > 0)
                        {
                            posParameters = posParameterMapper.ToObjects(posList)
                             .ToList();
                            foreach (var item in posParameterCategories)
                            {
                                item.POSParameters = new List<POSParameterModel>();
                                var posListToAdd = posParameters.Where(x => x.POSParameterCategoryId == item.Id).ToList();
                                item.POSParameters.AddRange(posListToAdd);
                            }
                        }
                    }
                }

                return posParameterCategories;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Loads the add position pop up.
        /// </summary>
        /// <returns>returns _AddPosParameter partialview.</returns>
        public async Task<ActionResult> LoadAddPosPopUp()
        {
            try
            {
                POSParameterModel posParameters = new POSParameterModel();
                List<POSParmeterCategoryModel> posParameterCategories = new List<POSParmeterCategoryModel>();
                var responseParamCat = await Get("POSParameterCategory/GetAllPOSParameterCategories");
                if (responseParamCat.StatusCode == HttpStatusCode.OK)
                {
                    var posCatList = await responseParamCat.Content.ReadAsAsync<List<POSParameterCategoryDto>>();
                    if (posCatList.Count > 0)
                    {
                        posParameterCategories = posParameterCategoryMapper.ToObjects(posCatList)
                           .ToList();
                        posParameters.PosCategoryList = posParameterCategories.Select(x => new SelectListItem
                        {
                            Text = x.ParameterCategory,
                            Value = x.Id.ToString()
                        })
                            .ToList();
                    }

                    return Json(new { Status = 1, Data = RenderRazorViewToString("_AddPosParameter", posParameters) });
                }

                return Json(new { Status = 0, Data = RenderRazorViewToString("_AddPosParameter", posParameters) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new
                {
                    Status = 0,
                    Data = "error",
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Creates the position parameter.
        /// </summary>
        /// <param name="posParameterModel">The position parameter model.</param>
        /// <returns>returns pos_List partial view.</returns>
        public async Task<ActionResult> CreatePosParameter(POSParameterModel posParameterModel)
        {
            try
            {
                List<POSParmeterCategoryModel> posParameterCategories = new List<POSParmeterCategoryModel>();
                if (posParameterModel != null)
                {
                    var posParameters = posParameterMapper.ToEntity(posParameterModel);
                    var creationResponse = await Post("POS/AddPOSParameter", posParameters);
                    if (creationResponse.StatusCode == HttpStatusCode.Created)
                    {
                        posParameterCategories = await GetAllPosParameters();
                        return Json(new { Status = 1, Data = RenderRazorViewToString("pos_List", posParameterCategories), Message = creationResponse.ReasonPhrase });
                    }
                    else
                    {
                        return Json(new { Status = 0, Message = creationResponse.ReasonPhrase });
                    }
                }

                return Json(new { Status = 0, Message = string.Empty });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new
                {
                    Status = 0,
                    Data = "error",
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Loads the edit position pop up.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns _EditPosParameter partial view.</returns>
        public async Task<ActionResult> LoadEditPosPopUp(int id)
        {
            try
            {
                List<POSParmeterCategoryModel> posParameterCategories = new List<POSParmeterCategoryModel>();
                POSParameterModel posParameter = new POSParameterModel();
                var posItem = new POSParameterDto();
                var response = await Get("POS/GetPOSParameterById/" + id);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    posItem = await response.Content.ReadAsAsync<POSParameterDto>();
                    posParameter = posParameterMapper.ToObject(posItem);
                    var responseParamCat = await Get("POSParameterCategory/GetAllPOSParameterCategories");
                    var posCatList = await responseParamCat.Content.ReadAsAsync<List<POSParameterCategoryDto>>();
                    if (posCatList.Count > 0)
                    {
                        posParameterCategories = posParameterCategoryMapper.ToObjects(posCatList)
                           .ToList();
                        posParameter.PosCategoryList = posParameterCategories.Select(x => new SelectListItem
                        {
                            Text = x.ParameterCategory,
                            Value = x.Id.ToString()
                        })
                            .ToList();
                    }

                    return Json(new { Status = 1, Data = RenderRazorViewToString("_EditPosParameter", posParameter), IsActive = posItem.IsActive });
                }
                else
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new
                {
                    Status = 0,
                    Data = "error",
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Updates the position parameter.
        /// </summary>
        /// <param name="posParameterModel">The position parameter model.</param>
        /// <returns>returns pos_List partial view.</returns>
        public async Task<ActionResult> UpdatePosParameter(POSParameterModel posParameterModel)
        {
            try
            {
                List<POSParmeterCategoryModel> posParameterCategories = new List<POSParmeterCategoryModel>();
                if (posParameterModel != null)
                {
                    var posParameters = posParameterMapper.ToEntity(posParameterModel);
                    var creationResponse = await Put("POS/UpdatePOSParameter", posParameters);
                    if (creationResponse.StatusCode == HttpStatusCode.OK)
                    {
                        posParameterCategories = await GetAllPosParameters();
                        return Json(new { Status = 1, Data = RenderRazorViewToString("pos_List", posParameterCategories), Message = creationResponse.ReasonPhrase });
                    }
                    else
                    {
                        return Json(new { Status = 0, Message = creationResponse.ReasonPhrase });
                    }
                }

                return Json(new { Status = 0, Message = string.Empty });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new
                {
                    Status = 0,
                    Data = "error",
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Deletes the position.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns pos_List partial view.</returns>
        public async Task<ActionResult> DeletePos(int id)
        {
            try
            {
                List<POSParmeterCategoryModel> posParameterCategories = new List<POSParmeterCategoryModel>();
                var response = await Delete("POS/DeletePOSParameter/" + id);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    posParameterCategories = await GetAllPosParameters();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("pos_List", posParameterCategories), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new
                {
                    Status = 0,
                    Data = "error",
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Activates the position.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns pos_List partial view.</returns>
        public async Task<ActionResult> ActivatePos(int id)
        {
            try
            {
                List<POSParmeterCategoryModel> posParameterCategories = new List<POSParmeterCategoryModel>();
                var response = await Put("POS/ChangePOSParameterStatus/paramId/" + id + "/activeId/1", null);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    posParameterCategories = await GetAllPosParameters();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("pos_List", posParameterCategories), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new
                {
                    Status = -1,
                    Data = "error",
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Des the activate position.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns pos_List partial view.</returns>
        public async Task<ActionResult> DeActivatePos(int id)
        {
            try
            {
                List<POSParmeterCategoryModel> posParameterCategories = new List<POSParmeterCategoryModel>();
                var response = await Put("POS/ChangePOSParameterStatus/paramId/" + id + "/activeId/0", null);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    posParameterCategories = await GetAllPosParameters();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("pos_List", posParameterCategories), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new
                {
                    Status = -1,
                    Data = "error",
                    Message = ex.Message
                });
            }
        }

        #endregion
    }
}