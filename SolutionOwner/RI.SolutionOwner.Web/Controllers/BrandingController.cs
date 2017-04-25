//-----------------------------------------------------------
// <copyright file="BrandingController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------

namespace RI.SolutionOwner.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using DTOs;
    using Framework.Core.Logging.Contracts;
    using RI.SolutionOwner.Mapper;
    using RI.SolutionOwner.Web.Models;
   
    /// <summary>
    /// This class implements the client side functionality of branding
    /// </summary>
    public class BrandingController : BaseController
    {
        #region PrivateMembers
        /// <summary>
        /// Declare brandmapper variable that maps brand entity to view model
        /// </summary>
        private ObjectMapper<SOBrandingDto, BrandingViewModel> brandMapper;

        /// <summary>
        /// logger service
        /// </summary>
        private ILoggerExtension logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandingController"/> class.
        /// </summary>
        /// <param name="brandMapper">brandmapper that maps brand entity to view model</param>
        /// <param name="logger">logger service</param>
        public BrandingController(ObjectMapper<SOBrandingDto, BrandingViewModel> brandMapper, ILoggerExtension logger)
        {
            this.brandMapper = brandMapper;
            this.logger = logger;
        }
        #endregion

        #region Methods and actions
        /// <summary>
        /// Branding action loads the fields for adding/editing
        /// </summary>
        /// <returns>BrandingViewModel data</returns>
        [HttpGet]
        public async Task<ActionResult> Edit()
        {
            BrandingViewModel model = new BrandingViewModel();
            model.ResponseStatus = false;
            try
            {
                HttpResponseMessage response = await Get("Branding/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsAsync<SOBrandingDto>();
                    if (response.StatusCode == HttpStatusCode.OK && responseContent != null)
                    {
                        model = brandMapper.ToObject(responseContent);
                        model.ResponseStatus = true;
                    }
                }

                model.ResponseMsg = response.ReasonPhrase;
                response = await Get("SPCurrency/GetAllCurrency");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsAsync<List<SPCurrencyDto>>();
                    if (response.StatusCode == HttpStatusCode.OK && responseContent.Count() > 0)
                    {
                        model.BaseCurrencyList = responseContent.AsEnumerable().Select(s => new SelectListItem() { Text = s.Currency, Value = s.Id.ToString(), Selected = s.Id == model.BaseCurrencyID });
                    }
                    else
                    {
                        model.BaseCurrencyList = new List<SelectListItem>();
                    }
                }
                else
                {
                    model.BaseCurrencyList = new List<SelectListItem>();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Branding- Edit " + ex.Message);
            }

            return View(model);
        }

        /// <summary>
        /// This action posting data for adding or updating
        /// </summary>
        /// <param name="model">BrandingViewModel for posting data</param>
        /// <returns>status response</returns>
        [HttpPost]
        public async Task<ActionResult> Edit(BrandingViewModel model)
        {
            HttpResponseMessage response = null;
            model.ResponseStatus = false;
            try
            {
                if (model.Id > 0)
                {
                    response = await Put("Branding/Update", brandMapper.ToEntity(model));
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            model.ResponseStatus = true;
                        }
                    }

                    model.ResponseMsg = response.ReasonPhrase;
                }
                else
                {
                    response = await Post("Branding/Create", brandMapper.ToEntity(model));
                    model.ResponseMsg = response.ReasonPhrase;
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.Created)
                        {
                            model.ResponseStatus = true;
                        }
                    }
                }

                return Json(model.ResponseStatus, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error("Branding- Edit Post" + ex.Message);
            }

            return View("Edit");
        }

        /// <summary>
        /// Remove file
        /// </summary>
        /// <param name="fileName">file name</param>
        public void RemoveFile(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                FileInfo fi = new FileInfo(Server.MapPath("~/Uploads/" + fileName));
                if (fi.Exists)
                {
                    fi.Delete();
                }
            }
        }

        /// <summary>
        /// This action shows the saved fields in view mode
        /// </summary>
        /// <returns>brand view model</returns>
        [HttpGet]
        public async Task<ActionResult> ViewBranding()
        {
            BrandingViewModel model = new BrandingViewModel();
            model.ResponseStatus = false;
            HttpResponseMessage response = null;
            try
            {
                using (response = await Get("Branding/GetAll"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsAsync<SOBrandingDto>();
                        if (response.StatusCode == HttpStatusCode.OK && responseContent != null)
                        {
                            model = brandMapper.ToObject(responseContent);
                            model.ResponseStatus = true;
                        }
                    }

                    model.ResponseMsg = response.ReasonPhrase;
                }

                using (response = await Get("SPCurrency/GetCurrencyById/" + model.BaseCurrencyID))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsAsync<SPCurrencyDto>();
                        if (response.StatusCode == HttpStatusCode.OK && responseContent != null)
                        {
                            model.CurrencyName = responseContent.Currency;
                        }
                        else
                        {
                            model.CurrencyName = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                model.ResponseMsg = ex.Message;
            }

            return View(model);
        }

        /// <summary>
        /// Upload logo file for cropping
        /// </summary>
        /// <returns>Uploaded file name</returns>
        public ActionResult UploadFileData()
        {
            string fileName = string.Empty;
            try
            {
                string result = string.Empty;

                HttpPostedFileBase filesToupload = Request.Files[0] as HttpPostedFileBase;
                if (filesToupload.ContentLength > 0)
                {
                    fileName = Path.GetFileName(filesToupload.FileName);
                    filesToupload.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Branding- UploadFileData " + ex.Message);
            }

            return Json(fileName, "text/html", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get brand image logo
        /// </summary>
        /// <returns>Status response and image data</returns>
        public async Task<ActionResult> GetLogo()
        {
            string imgData = string.Empty;
            string imgThumbData = string.Empty;
            bool status = false;
            try
            {
                HttpResponseMessage response = await Get("Branding/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsAsync<SOBrandingDto>();
                    if (response.StatusCode == HttpStatusCode.OK && responseContent != null)
                    {
                        var brandObj = brandMapper.ToObject(responseContent);
                        if (brandObj != null)
                        {
                            imgData = string.IsNullOrEmpty(brandObj.ImgData) ? string.Empty : brandObj.ImgData;
                            imgThumbData = string.IsNullOrEmpty(brandObj.ImgThumbData) ? string.Empty : brandObj.ImgThumbData;
                            status = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Branding- GetLogo " + ex.Message);
            }

            return Json(new { Status = status, ImgData = imgData, ImgThumbData = imgThumbData }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}