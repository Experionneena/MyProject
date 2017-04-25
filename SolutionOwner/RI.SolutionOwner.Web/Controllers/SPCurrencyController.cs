// ---------------------------------------------------------
// <copyright file="SPCurrencyController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------

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
    /// Class SPCurrencyController
    /// </summary>
    public class SPCurrencyController : BaseController
    {
        #region Properties
        /// <summary>
        /// The service provider
        /// </summary>
        private IServiceProvider serviceProvider;

        /// <summary>
        /// The currency mapper
        /// </summary>
        private ObjectMapper<SPCurrencyRateDto, CurrencyRateModel> currencyMapper;

        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCurrencyController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="currencyMapper">The currency mapper.</param>
        /// <param name="logger">The logger.</param>
        public SPCurrencyController(IServiceProvider serviceProvider, ObjectMapper<SPCurrencyRateDto, CurrencyRateModel> currencyMapper, ILoggerExtension logger)
        {
            this.serviceProvider = serviceProvider;
            this.currencyMapper = currencyMapper;
            this.logger = logger;
        }
        #endregion

        #region Public Functions

        /// <summary>
        /// Index View
        /// </summary>
        /// <returns>Return view</returns>
        public ActionResult Index()
        {
            List<CurrencyRateModel> currencyList = new List<CurrencyRateModel>();
            return View(currencyList);
        }

        /// <summary>
        /// Gets all currency rate.
        /// </summary>
        /// <returns>List of CurrencyRateModel</returns>
        public async Task<List<CurrencyRateModel>> GetAllCurrencyRate()
        {
            try
            {
                var currencyList = new List<CurrencyRateModel>();
                var response = await Get("SPCurrencyRate/GetAllCurrencyRate");

                if (response.IsSuccessStatusCode)
                {
                    currencyList = currencyMapper.ToObjects(await response.Content.ReadAsAsync<IEnumerable<SPCurrencyRateDto>>()).ToList();
                    ////var stringContent = await response.Content.ReadAsStringAsync();

                    ////var settings = new JsonSerializerSettings()
                    ////{
                    ////    TypeNameHandling = TypeNameHandling.All
                    ////};
                    ////var instance = serviceProvider.GetService(typeof(ISPCurrencyRate));                   

                    ////var v2 = instance.GetType().GetProperty("Value").GetValue(instance, null);

                    ////var deserialized = JsonConvert.DeserializeObject<>(stringContent, );

                    ////currencyList = this.currencyMapper.ToObjects(deserialized).ToList();
                }

                return currencyList;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return null;
            }
        }

        ////private Person SerializeAndDeserialize(Person person)
        ////{
        ////    var indented = Formatting.Indented;
        ////    var settings = new JsonSerializerSettings()
        ////    {
        ////        TypeNameHandling = TypeNameHandling.All
        ////    };
        ////    var serialized = JsonConvert.SerializeObject(person, indented, settings);
        ////    var deserialized = JsonConvert.DeserializeObject(serialized, settings);
        ////    return deserialized;
        ////}

        /// <summary>
        /// Gets the currency list.
        /// </summary>
        /// <returns>Returns a list</returns>
        public async Task<ActionResult> GetCurrencyList()
        {
            try
            {
                List<CurrencyRateModel> currencyList = new List<CurrencyRateModel>();
                var brandingDetails = new SOBrandingDto();
                var currencyDetails = new SPCurrencyDto();

                currencyList = await GetAllCurrencyRate();
                var response = await Get("Branding/GetAll");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    brandingDetails = await response.Content.ReadAsAsync<SOBrandingDto>();
                }

                var baseCurrencyResponse = await Get("SPCurrency/GetCurrencyById/" + brandingDetails.BaseCurrencyID);
                if (baseCurrencyResponse.StatusCode == HttpStatusCode.OK)
                {
                    currencyDetails = await baseCurrencyResponse.Content.ReadAsAsync<SPCurrencyDto>();
                }

                return Json(new { Status = 1, Data = RenderRazorViewToString("_CurrencyList", currencyList), BaseCurrency = currencyDetails.Currency });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all currency.
        /// </summary>
        /// <returns>Dictionary of string and integer</returns>
        public async Task<Dictionary<string, int>> GetAllCurrency()
        {
            try
            {
                var currencyKeyValue = new Dictionary<string, int>();

                var response = await Get("SPCurrency/GetAllCurrency");

                if (response.IsSuccessStatusCode)
                {
                    var currencyList = (await response.Content.ReadAsAsync<IEnumerable<SPCurrencyDto>>()).ToList();

                    currencyKeyValue.Add(string.Empty, 0);
                    foreach (var currency in currencyList)
                    {
                        currencyKeyValue.Add(currency.Currency, currency.Id);
                    }
                }

                return currencyKeyValue;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Currencies the edit.
        /// </summary>
        /// <param name="currencyRate">The currency rate.</param>
        /// <returns>Return a view</returns>
        public async Task<ActionResult> CurrencyEdit(CurrencyRateModel currencyRate)
        {
            try
            {
                var response = await Put("SPCurrencyRate/UpdateCurrency", currencyRate);
                List<CurrencyRateModel> currencyList = new List<CurrencyRateModel>();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    currencyList = await GetAllCurrencyRate();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_CurrencyList", currencyList), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Data = "Error", Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Add user popup
        /// </summary>
        /// <returns>Return a view</returns>
        public async Task<ActionResult> AddCurrencyRatePopUp()
        {
            try
            {
                CurrencyRateModel currencyRate = new CurrencyRateModel();
                var response = await Get("SPCurrencyRate/GetAllCurrencyRate");

                currencyRate.SymbolId = await GetAllCurrency();
                currencyRate.Rate = 1;
                return Json(new { Status = 1, Data = RenderRazorViewToString("_AddCurrencyRatePopUp", currencyRate) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Activates the deactivate currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>Return a view</returns>
        public async Task<ActionResult> ActivateDeactivateCurrency(int id, int flag)
        {
            try
            {
                List<CurrencyRateModel> currencyList = new List<CurrencyRateModel>();

                var response = await Put("SPCurrencyRate/ActivateDeactivateCurrencyRate" + "?id=" + id + "&flag=" + flag, null);
                currencyList = await GetAllCurrencyRate();
                return Json(new { Status = 1, Data = RenderRazorViewToString("_CurrencyList", currencyList), Message = response.ReasonPhrase });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Currencies the add.
        /// </summary>
        /// <param name="currencyModel">The currency model.</param>
        /// <returns>Return a view</returns>
        public async Task<ActionResult> CurrencyAdd(CurrencyRateModel currencyModel)
        {
            try
            {
                var currency = currencyMapper.ToEntity(currencyModel);
                var response = await Post("SPCurrencyRate/CreateCurrencyDescription", currency);
                List<CurrencyRateModel> currencyList = new List<CurrencyRateModel>();
                currencyList = await GetAllCurrencyRate();

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_CurrencyList", currencyList), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Data = "Error", Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the currency by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Return a view</returns>
        public async Task<ActionResult> DeleteCurrencyById(int userId)
        {
            try
            {
                List<CurrencyRateModel> currencyList = new List<CurrencyRateModel>();

                var response = await Delete("SPCurrencyRate/DeleteCurrency/" + userId);

                if (response.IsSuccessStatusCode)
                {
                    currencyList = await GetAllCurrencyRate();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_CurrencyList", currencyList), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Data = "Error", Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the currency rate by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Model CurrencyRateModel</returns>
        public async Task<CurrencyRateModel> GetCurrencyRateById(int userId)
        {
            CurrencyRateModel currencyRate = new CurrencyRateModel();
            try
            {
                var response = await Get("SPCurrencyRate/GetCurrency/" + userId);

                if (response.IsSuccessStatusCode)
                {
                    currencyRate = currencyMapper.ToObject(await response.Content.ReadAsAsync<SPCurrencyRateDto>());
                }

                currencyRate.SymbolId = await GetAllCurrency();

                return currencyRate;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets the currency details for edit by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Return a view</returns>
        public async Task<ActionResult> GetCurrencyDetailsForEditById(int userId)
        {
            try
            {
                var currencyModel = await GetCurrencyRateById(userId);
                var response = await Get("SPCurrency/GetCurrencyById/" + currencyModel.CurrencyId);
                if (response.IsSuccessStatusCode)
                {
                    ////var currency = await response.Content.ReadAsAsync<SPCurrency>();

                    return Json(new { Status = 1, Data = RenderRazorViewToString("_EditCurrencyRatePopUp", currencyModel), currencyList = currencyModel.SymbolId, Id = currencyModel.CurrencyId });
                }
                else
                {
                    return Json(new { Status = 0, Data = "Error", Message = response.ReasonPhrase, });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }
        #endregion
    }
}