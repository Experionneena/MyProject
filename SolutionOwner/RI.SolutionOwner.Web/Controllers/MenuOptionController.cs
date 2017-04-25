using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Web.Models;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Web.Controllers
{
    public class MenuOptionController : BaseController
    {
        #region Public Members
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        #region Private Members

        /// <summary>
        /// The App user manager.
        /// </summary>
        private ApplicationUserManager _userManager = null;

        /// <summary>
        /// The service provider.
        /// </summary>
        private IServiceProvider _serviceProvider = null;             

        /// <summary>
        /// The menu option mapper.
        /// </summary>
        ObjectMapper<ISOMenu, MenuOptionViewModel> _menuOptionMapper;

        #endregion

        #region Constructor
        public MenuOptionController(ObjectMapper<ISOMenu, MenuOptionViewModel> menuOptionMapper)
        {            
            _menuOptionMapper = menuOptionMapper;
        }
        #endregion

        #region Public Methods / Actions

        public ActionResult Index()
        {
            var awaitFeatureCollection = Task.Run(async () =>
            {
                return await _featureService.GetAllFeatures();
            });
            var features = awaitFeatureCollection.Result.ToList();
            var menuOptionList = _menuOptionService.GetAllMenu();
            var menuOptionVM = _menuOptionMapper.ToObjects(menuOptionList)
                .ToList();
            menuOptionVM
                .ForEach(x => x.URLPath = features.Find(f => f.Id == x.FeatureId).ProgramLink);

            return View(menuOptionVM);
        }

        public List<MenuOptionViewModel> GetAllMenuOptions()
        {
            var collection = _menuOptionService.GetAllMenu();
            var menuOptionList = _menuOptionMapper.ToObjects(collection)
                .ToList();
            return menuOptionList;
        }

        public ActionResult LoadAddPopUp()
        {
            var menuOptionVM = new Models.MenuOptionViewModel();
            menuOptionVM.MenuList = MakeMenuSelectList();
            menuOptionVM.FeatureList = MakeFeatureSelectList();
            return PartialView("_AddPopUp", menuOptionVM);
        }

        public ActionResult AddMenuOption(MenuOptionViewModel menuOptionVM)
        {
            try
            {
                var menuOptionEntity = _menuOptionMapper.ToEntity(menuOptionVM);
                _menuOptionService.CreateMenu(menuOptionEntity);
                var menuOptionList = _menuOptionService.GetAllMenu();
                return Json(new { Status = 1, Data = menuOptionList });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0 });
            }
        }

        public ActionResult LoadEditPopUp(long menuOptionId)
        {
            var menuOption = _menuOptionService.GetMenuOptionById(menuOptionId);
            var menuOptionVM = _menuOptionMapper.ToObject(menuOption);
            menuOptionVM.MenuList = MakeMenuSelectList(menuOptionVM.ParentMenuId);
            menuOptionVM.FeatureList = MakeFeatureSelectList(menuOptionVM.FeatureId);

            return PartialView("_EditPopUp", menuOptionVM);
        }

        public ActionResult EditMenuOption(MenuOptionViewModel menuOptionVM)
        {
            try
            {
                var menuOptionEntity = _menuOptionMapper.ToEntity(menuOptionVM);
                bool isSuccess = _menuOptionService.EditMenu(menuOptionEntity);
                var menuOptionList = _menuOptionService.GetAllMenu();
                return Json(new { Status = (isSuccess) ? 1 : 0, Data = menuOptionList });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0 });
            }
        }

        public ActionResult DeleteMenuOption(int menuOptionId)
        {
            try
            {
                var isMenuAssigned = _menuOptionService.CheckMenuIsAssignedTRoRole(menuOptionId);
                if (!isMenuAssigned)
                {
                    var isSuccess = _menuOptionService.DeleteMenu(menuOptionId);
                    var menuOptionList = _menuOptionService.GetAllMenu();
                    return Json(new { Status = (isSuccess) ? 1 : 0, Data = menuOptionList });
                }
                var menuOptions = _menuOptionService.GetAllMenu();
                return Json(new { Status = 0, Data = menuOptions });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0 });
            }
        }

        public ActionResult DeActivateMenuOption(int menuOptionId)
        {
            try
            {
                var isMenuAssigned = _menuOptionService.CheckMenuIsAssignedTRoRole(menuOptionId);
                var menuEntity = _menuOptionService.GetMenuOptionById(menuOptionId);

                if (!isMenuAssigned)
                {
                    menuEntity.EditedDate = DateTime.Now;
                    menuEntity.IsActive = false;
                    var isSuccess = _menuOptionService.EditMenu(menuEntity);
                    var menuOptionList = _menuOptionService.GetAllMenu();
                    return Json(new { Status = (isSuccess) ? 1 : 0, Data = menuOptionList });
                }
                var menuOptions = _menuOptionService.GetAllMenu();
                return Json(new { Status = 0, Data = menuOptions });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0 });
            }
        }

        #endregion

        #region Private Methods

        private List<SelectListItem> MakeMenuSelectList(int selectedValue = 0)
        {
            var menuList = _menuOptionService.GetAllMenu()
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

        private List<SelectListItem> MakeFeatureSelectList(int selectedValue = 0)
        {
            var allFearures = Task.Run(async () =>
            {
                return await _featureService.GetAllFeatures();
            });
            var featureList = allFearures.Result
                .Select(x => new 
                SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToList();

            if (featureList.Any(x => x.Value == selectedValue.ToString()))
            {
                featureList
                    .FirstOrDefault(x => x.Value == selectedValue.ToString())
                    .Selected = true;
            }
            else if (featureList.Any())
            {
                featureList.First().Selected = true;
            }
            return featureList;
        }

        #endregion
    }
}