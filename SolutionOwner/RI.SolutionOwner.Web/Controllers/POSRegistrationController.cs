//----------------------------------------------------------
// <copyright file="POSRegistrationController.cs" company="RechargeIndia">
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
    public class POSRegistrationController : BaseController
    {
        #region Private Members
        /// <summary>
        /// The service provider
        /// </summary>
        private IServiceProvider serviceProvider;

        /// <summary>
        /// The pos parameter mapper
        /// </summary>
        private ObjectMapper<POSDto, POSViewModel> posMapper;

        /// <summary>
        /// Supplier Mapper
        /// </summary>
        private ObjectMapper<SupplierDto, SupplierViewModel> supplierMapper;
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

        public POSRegistrationController(
                                  IServiceProvider serviceProvider,
                                  ObjectMapper<POSDto, POSViewModel> posMapper, ObjectMapper<SupplierDto, SupplierViewModel> supplierMapper ,
                                  ILoggerExtension logger)

        {
            this.serviceProvider = serviceProvider;
            this.posMapper = posMapper;
            this.supplierMapper = supplierMapper;
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
        /// Gets all position parameters.
        /// </summary>
        /// <returns>returns list of POSParmeterCategoryModel.</returns>
        public async Task<ActionResult> GetAllPos()

        {
            try
            {
                List<POSViewModel> posList = new List<POSViewModel>();

                var responseParamCat = await Get("POSRegistration/GetAllPOS");
              
                    var posListDto = await responseParamCat.Content.ReadAsAsync<List<POSDto>>();
                    posList = posMapper.ToObjects(posListDto).ToList();

                    List<SupplierViewModel> supplierList = new List<SupplierViewModel>();
                    var supplierResponse = await Get("Supplier/GetAllSuppliers");
                    var supplierListContent = await supplierResponse.Content.ReadAsAsync<IEnumerable<SupplierDto>>();
                    supplierList = supplierMapper.ToObjects(supplierListContent).ToList();
                var listForRendering = SetPosViewModel(supplierList, posList);
                return Json(new { Status = 1, Data = RenderRazorViewToString("_PosList", listForRendering) }, JsonRequestBehavior.AllowGet);
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
               POSViewModel posVm = new POSViewModel();
                var posList = new List<POSViewModel>();
                var response = await Get("POSRegistration/GetAllPOS");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var posListContent = await response.Content.ReadAsAsync<IEnumerable<POSDto>>();

                    posList = posMapper.ToObjects(posListContent).ToList();
                    List<SupplierViewModel> supplierList = new List<SupplierViewModel>();
                    var supplierResponse = await Get("Supplier/GetAllSuppliers");
                    if (supplierResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var supplierListContent = await supplierResponse.Content.ReadAsAsync<IEnumerable<SupplierDto>>();
                        supplierList = supplierMapper.ToObjects(supplierListContent).ToList();
                        supplierList.ForEach(c => c.SupplierList = supplierList.Where(x => x.Id == c.Id).ToList());
                        //supplierList = supplierList
                        //   .Where(x => x.Id == 0)
                        //   .ToList();

                        posVm.SupplierViewModelList = supplierList;
                    }
                }
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_AddPos", posVm) });
            }

            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Creates the position parameter.
        /// </summary>
        /// <param name="posParameterModel">The position parameter model.</param>
        /// <returns>returns pos_List partial view.</returns>
        public async Task<ActionResult> CreatePos(POSViewModel posModel)
        {
            try
            {
                List<POSViewModel> posModelList = new List<POSViewModel>();

                var posParameters = posMapper.ToEntity(posModel);
                var creationResponse = await Post("POSRegistration/CreatePOS", posParameters);
                if (creationResponse.StatusCode == HttpStatusCode.Created)
                {
                    List<POSViewModel> posList = new List<POSViewModel>();
                    var responsePos = await Get("POSRegistration/GetAllPOS");
                 
                        posList = posMapper.ToObjects(await responsePos.Content.ReadAsAsync<List<POSDto>>()).ToList();

                        List<SupplierViewModel> supplierList = new List<SupplierViewModel>();
                        var supplierResponse = await Get("Supplier/GetAllSuppliers");
                        var supplierListContent = await supplierResponse.Content.ReadAsAsync<IEnumerable<SupplierDto>>();
                        supplierList = supplierMapper.ToObjects(supplierListContent).ToList();
                        var listForRendering = SetPosViewModel(supplierList, posList);


                        return Json(new { Status = 1, Data = RenderRazorViewToString("_PosList", listForRendering), Message = creationResponse.ReasonPhrase });
                    
                }
                else
                {
                    return Json(new { Status = 0, Message = creationResponse.ReasonPhrase });
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
        /// Loads the edit position pop up.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns _EditPosParameter partial view.</returns>
        public async Task<ActionResult> LoadEditPosPopUp(int id)
        {
            try
            {
                POSViewModel posItemModel = new POSViewModel();
                List<POSViewModel> posFullList = new List<POSViewModel>();
                var posItem = new POSDto();
                var response = await Get("POSRegistration/GetPOSById/" + id);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    posItem = await response.Content.ReadAsAsync<POSDto>();
                    posItemModel = posMapper.ToObject(posItem);

                    //var responseParam= await Get("POSRegistration/GetAllPOS");
                    //var pos = await responseParam.Content.ReadAsAsync<List<POSDto>>();
                    //if (pos.Count > 0)
                    //{
                    //    posFullList = posMapper.ToObjects(pos)
                    //       .ToList();
                      
                    //}

                    return Json(new { Status = 1, Data = RenderRazorViewToString("_EditPos", posItemModel), IsActive = posItem.IsActive });
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
        public async Task<ActionResult> UpdatePos(POSViewModel posviewModel)
        {
            try
            {
                List<POSViewModel> posView = new List<POSViewModel>();
                if (posviewModel != null)
                {
                    var posParameters = posMapper.ToEntity(posviewModel);
                    var creationResponse = await Put("POSRegistration/UpdatePOS", posParameters);
                    List<POSViewModel> posListModel = new List<POSViewModel>();
                    if (creationResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var posList = await Get("POSRegistration/GetAllPOS");
                        if (creationResponse.IsSuccessStatusCode)
                        {
                            posListModel = posMapper.ToObjects(await posList.Content.ReadAsAsync<List<POSDto>>()).ToList();

                        }
                        return Json(new { Status = 1, Data = RenderRazorViewToString("_posList", posListModel), Message = creationResponse.ReasonPhrase });
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

        //        /// <summary>
        //        /// Deletes the position.
        //        /// </summary>
        //        /// <param name="id">The identifier.</param>
        //        /// <returns>returns pos_List partial view.</returns>
        public async Task<ActionResult> DeletePos(int id)
        {
            try
            {
                List<POSViewModel> pos = new List<POSViewModel>();
                var response = await Delete("POSRegistration/DeletePOS/" + id);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responsePos = await Get("POSRegistration/GetAllPOS");
                    if (responsePos.IsSuccessStatusCode)
                    {
                        pos = posMapper.ToObjects(await responsePos.Content.ReadAsAsync<List<POSDto>>()).ToList();
                    }

                    return Json(new { Status = 1, Data = RenderRazorViewToString("_PosList", pos), Message = response.ReasonPhrase });
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

        //        /// <summary>
        //        /// Activates the position.
        //        /// </summary>
        //        /// <param name="id">The identifier.</param>
        //        /// <returns>returns pos_List partial view.</returns>
        public async Task<ActionResult> ActivateDeactivatePOS(int posId, int flag)
        {
            try
            {
                List<POSViewModel> posModel = new List<POSViewModel>();
                var response = await Put("POSRegistration/ActivateDeactivatePOS/" + posId + "/" + flag, null);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responsePos = await Get("POSRegistration/GetAllPOS");
                    posModel = posMapper.ToObjects(await responsePos.Content.ReadAsAsync<List<POSDto>>()).ToList();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_PosList", posModel), Message = response.ReasonPhrase });
                }
                else
                {
                    var responsePos = await Get("POSRegistration/GetAllPOS");
                    posModel = posMapper.ToObjects(await responsePos.Content.ReadAsAsync<List<POSDto>>()).ToList();
                    return Json(new { Status = 0, Data = RenderRazorViewToString("_PosList", posModel), Message = response.ReasonPhrase });
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

    

        private List<POSViewModel> SetPosViewModel(List<SupplierViewModel> supplierModel, List<POSViewModel> posModel)
        {
            POSViewModel pos = new POSViewModel();
            pos.SupplierViewModelList = new List<SupplierViewModel>();
            List<SupplierViewModel> supplierList = new List<SupplierViewModel>();
            try
            {
                foreach(var item in posModel)
                {
                    item.Supplier = supplierModel.Where(x => x.Id == item.SupplierId).FirstOrDefault().SupplierName;
                }
                return posModel;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }
        #endregion
    }
}