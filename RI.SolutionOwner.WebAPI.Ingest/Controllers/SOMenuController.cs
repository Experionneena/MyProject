using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.WebAPI.Ingest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    //[Authorize]
    //[RoutePrefix("api/MenuOption")]
    public class SOMenuController : ApiController
    {
        #region Private Members


        /// <summary>
        /// The feature data service.
        /// </summary>
        private IFeatureDataService _featureDataService = null;       

        #endregion

        #region Constructor
        public SOMenuController(
            //ApplicationUserManager userManager,
            //ISecureDataFormat<AuthenticationTicket> accessTokenFormat
            IFeatureDataService featureDataService)
        {
            //UserManager = userManager;
            //AccessTokenFormat = accessTokenFormat;
            _featureDataService = featureDataService;          
        }
        #endregion

        #region Public Methods

        [System.Web.Http.HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                var httpResponse = new HttpResponseMessage();
                var awaitFeatureCollection = Task.Run(async () =>
                {
                    return await _featureDataService.GetAllFeatures();
                });
                var features = awaitFeatureCollection.Result.ToList();
                var menuOptionList = _menuDataService.GetAllMenu();
                var menuOptionVM = _menuMapper.ToObjects(menuOptionList)
                    .ToList();
                menuOptionVM
                    .ForEach(x => x.URLPath = features.Find(f => f.Id == x.FeatureId).ProgramLink);
                return httpResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public HttpResponseMessage GetAllMenus()
        {
            try
            {
                var httpResponse = new HttpResponseMessage();
                var collection = _menuDataService.GetAllMenu();
                var menuOptionList = _menuMapper.ToObjects(collection)
                    .ToList();
                return httpResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public HttpResponseMessage GetAddSOMenuPage()
        {
            try
            {
                var httpResponse = new HttpResponseMessage();
                var menuDto = new SOMenuModel();
                menuDto.MenuList = MakeMenuSelectList();
                return httpResponse;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public HttpResponseMessage CreateSOMenu(SOMenuModel menuDto)
        {
            try
            {
                var httpResponse = new HttpResponseMessage();

                menuDto.CreatedDate = DateTime.Now;
                menuDto.EditedDate = DateTime.Now;
                var menuEntity = _menuMapper.ToEntity(menuDto);
                _menuDataService.CreateMenu(menuEntity);
                var menuList = _menuDataService.GetAllMenu();
                return httpResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public HttpResponseMessage GetSOMenuById(long menuId)
        {
            try
            {
                var httpResponse = new HttpResponseMessage();
                var menuOption = _menuDataService.GetMenuOptionById(menuId);
                var menuOptionVM = _menuMapper.ToObject(menuOption);
                menuOptionVM.MenuList = MakeMenuSelectList(menuOptionVM.ParentMenuId);
                return httpResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public HttpResponseMessage UpdateSOMenu(SOMenuModel menuDto)
        {
            try
            {
                var httpResponse = new HttpResponseMessage();

                menuDto.EditedDate = DateTime.Now;
                var menuEntity = _menuMapper.ToEntity(menuDto);
                bool isSuccess = _menuDataService.EditMenu(menuEntity);
                var menuOptionList = _menuDataService.GetAllMenu();
                return httpResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public HttpResponseMessage DeleteMenu(int menuId)
        {
            try
            {
                var httpResponse = new HttpResponseMessage();

                var isMenuAssigned = _menuDataService.CheckMenuIsAssignedTRoRole(menuId);
                if (!isMenuAssigned)
                {
                    var menu = _menuDataService.GetMenuOptionById(menuId);
                    if (null != menu)
                    {
                        var isSuccess = _menuDataService.DeleteMenu(menu);
                    }
                    var menuOptionList = _menuDataService.GetAllMenu();
                    return httpResponse;
                }
                return httpResponse; //Return, cannot delete, its already assigned.
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public HttpResponseMessage ChangeMenuActiveStatus(int menuId)
        {
            try
            {
                var httpResponse = new HttpResponseMessage();

                var isMenuAssigned = _menuDataService.CheckMenuIsAssignedTRoRole(menuId);
                var menuEntity = _menuDataService.GetMenuOptionById(menuId);

                if (!isMenuAssigned)
                {
                    menuEntity.EditedDate = DateTime.Now;
                    menuEntity.IsActive = false;
                    var isSuccess = _menuDataService.EditMenu(menuEntity);
                    var menuOptionList = _menuDataService.GetAllMenu();
                    return httpResponse;
                }
                var menuOptions = _menuDataService.GetAllMenu();
                return httpResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Private Methods

        private List<SelectListItem> MakeMenuSelectList(int selectedValue = 0)
        {
            var menuList = _menuDataService.GetAllMenu()
                .OrderBy(x => x.ParentMenuId)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();

            if (menuList.Any(x => x.Value == selectedValue.ToString()))
            {
                menuList
                    .FirstOrDefault(x => x.Value == selectedValue.ToString())
                    .Selected = true;
            }
            else if (menuList.Any())
            {
                menuList.First().Selected = true;
            }
            return menuList;
        }

        #endregion
    }
}