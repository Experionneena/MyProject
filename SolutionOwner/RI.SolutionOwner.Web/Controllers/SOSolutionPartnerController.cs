//---------------------------------------------------------
// <copyright file="SOSolutionPartnerController.cs" company="RechargeIndia">
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
    /// The Solution owner Solution partner Controller
    /// </summary>
    public class SOSolutionPartnerController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The _logger
        /// </summary>
        private ILoggerExtension logger;

        /// <summary>
        /// The product group mapper
        /// </summary>
        private ObjectMapper<SOSolutionPartnerContactDto, SOSolutionPartnerContactsViewModel> contactMapper = null;
        #endregion

        #region Public Members

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSolutionPartnerController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="contactMapper">The contact mapper.</param>
        public SOSolutionPartnerController(ILoggerExtension logger, ObjectMapper<SOSolutionPartnerContactDto, SOSolutionPartnerContactsViewModel> contactMapper)
        {
            this.logger = logger;
            this.contactMapper = contactMapper;
        }

        #endregion

        #region Action Results / Public Methods

        #region Partner Contact Actions
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The Index.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Loads the contact pop up.
        /// </summary>
        /// <param name="partnerId">The sosp identifier.</param>
        /// <returns>The view.</returns>
        public async Task<ActionResult> LoadContactPopUp(int partnerId)
        {
            try
            {
                var contactViewModel = new SOSolutionPartnerContactsViewModel();
                contactViewModel.ContactList = await GetContactsBySolutionPartner(partnerId);
                return Json(new
                {
                    Status = 1,
                    Data = RenderRazorViewToString("_ContactList", contactViewModel),
                    Message = string.Empty
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new
                {
                    Status = 0,
                    Message = "Something wrong!"
                });
            }
        }

        /// <summary>
        /// Gets the contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>The Action.</returns>
        public async Task<ActionResult> GetContact(int contactId)
        {
            try
            {
                var contactList = new SOSolutionPartnerContactsViewModel();
                var response = await Get("api/SOSolutionPartnerContact?id=" + contactId);
                if (response.IsSuccessStatusCode)
                {
                    var contact = await response.Content.ReadAsAsync<SOSolutionPartnerContactDto>();
                    return Json(
                        new
                        {
                            Status = 1,
                            Data = contact,
                            Message = "Success."
                        });
                }

                return Json(new
                {
                    Status = 0,
                    Message = response.ReasonPhrase
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new
                {
                    Status = 0,
                    Message = "Something wrong!"
                });
            }
        }

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="contactViewModel">The contact view model.</param>
        /// <returns>The Action.</returns>
        public async Task<ActionResult> CreateContact(SOSolutionPartnerContactsViewModel contactViewModel)
        {
            try
            {
                var contactEntity = contactMapper.ToEntity(contactViewModel);
                var response = await Post("api/SOSolutionPartnerContact", contactEntity);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    var contactVM = new SOSolutionPartnerContactsViewModel();
                    contactVM.ContactList = await GetContactsBySolutionPartner(contactViewModel.SolutionPartnerId);
                    return Json(new
                    {
                        Status = 1,
                        Data = RenderRazorViewToString("_ContactList", contactVM),
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
        /// Edits the contact.
        /// </summary>
        /// <param name="contactViewModel">The contact view model.</param>
        /// <returns>The Action.</returns>
        public async Task<ActionResult> EditContact(SOSolutionPartnerContactsViewModel contactViewModel)
        {
            try
            {
                var contactEntity = contactMapper.ToEntity(contactViewModel);
                var response = await Put("api/SOSolutionPartnerContact", contactEntity);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var contactVM = new SOSolutionPartnerContactsViewModel();
                    contactVM.ContactList = await GetContactsBySolutionPartner(contactViewModel.SolutionPartnerId);
                    return Json(new
                    {
                        Status = 1,
                        Data = RenderRazorViewToString("_ContactList", contactVM),
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
        /// Deletes the contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="partnerId">The partner identifier.</param>
        /// <returns>The Action.</returns>
        public async Task<ActionResult> DeleteContact(int contactId, int partnerId)
        {
            try
            {
                var response = await Delete("api/SOSolutionPartnerContact?id=" + contactId);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    var contactVM = new SOSolutionPartnerContactsViewModel();
                    contactVM.ContactList = await GetContactsBySolutionPartner(partnerId);
                    return Json(new
                    {
                        Status = 1,
                        Data = RenderRazorViewToString("_ContactList", contactVM),
                        Message = response.ReasonPhrase
                    });
                }

                return Json(new { Status = 0, Message = response.ReasonPhrase });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        /// <summary>
        /// Loads the tabs for add.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Action Result</returns>
        public ActionResult LoadTabsForAdd(string name)
        {
            if (name == "1")
            {
                return Json(new
                {
                    Status = 1,
                    Data = RenderRazorViewToString("_GeneralSettingsAdd", null)
                });
            }
            else if (name == "2")
            {
                return Json(new
                {
                    Status = 1,
                    Data = RenderRazorViewToString("_AddressAdd", null)
                });
            }
            else if (name == "3")
            {
                return Json(new
                {
                    Status = 1,
                    Data = RenderRazorViewToString("_SFTPAddEdit", null)
                });
            }
            else
            {
                return Json(new
                {
                    Status = 1,
                    Data = RenderRazorViewToString("_HeriarchyAddEdit", null)
                });
            }
        }
        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the contacts by solution partner.
        /// </summary>
        /// <param name="partnerId">The sosp identifier.</param>
        /// <returns>The List.</returns>
        private async Task<List<SOSolutionPartnerContactsViewModel>> GetContactsBySolutionPartner(int partnerId)
        {
            var contactList = new List<SOSolutionPartnerContactsViewModel>();
            var response = await Get("api/SOSolutionPartnerContact?SOSPId=" + partnerId + "&dummyId=0");

            if (response.IsSuccessStatusCode)
            {
                var contacts = await response.Content.ReadAsAsync<List<SOSolutionPartnerContactDto>>();
                contactList = contactMapper.ToObjects(contacts)
                    .OrderByDescending(x => x.CreatedDate)
                    .ToList();
            }

            return contactList;
        }

        #endregion
    }
}