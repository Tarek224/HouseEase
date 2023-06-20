using HouseEase.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseEase.Models;
using HouseEase.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using HouseEase.Interfaces;

namespace HouseEase.Controllers
{
    public class AccountController : Controller
    {
        #region Ctor
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IUnityOfWork _unityOfWork;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            IUnityOfWork unityOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _unityOfWork = unityOfWork;
        }
        #endregion

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(_context.Roles.ToList(), "Id", "Name");  
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Email"] = model.Email;
                TempData["Password"] = model.Password;
                if (model.RoleId == "a1eaeb01-3683-43e1-8cr7-b731d0c655dz")
                    return RedirectToAction("TentantInformation", "Account");

                return RedirectToAction("OwnerInformation", "Account");
            }
            return View(model);
        }
        #endregion

        #region TentantInformation
        [HttpGet]
        public async Task<IActionResult> TentantInformation()
        {
            ViewBag.Govs = new SelectList(await _unityOfWork.Governurate.FindAllAsync(x => !x.IsDeleted), "Id", "Name");
            ViewBag.Univ = new SelectList(await _unityOfWork.University.FindAllAsync(x => !x.IsDeleted), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TentantInformation(TentantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = TempData["Email"].ToString(),
                    Email = TempData["Email"].ToString(),
                    EmailConfirmed = true,
                    IsTenant = true,
                    JobTitle = model.JobTitle,
                    MaritialStatus = model.MaritialStatus,
                    FullName = model.FullName,
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.MobileNumber,
                    PhoneNumberConfirmed = true,
                    CityId = model.CityId,
                    GovernurateId = model.GovernurateId,
                    IsSmoking = model.IsSmoking,
                    UniversityId = model.UniversityId,
                    FucltyId = model.FucltyId,
                };
                var result = await _userManager.CreateAsync(user, TempData["Password"].ToString());
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }
        #endregion

        #region OwnerInformation
        [HttpGet]
        public async Task<IActionResult> OwnerInformation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OwnerInformation(OwnerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = TempData["Email"].ToString(),
                    Email = TempData["Email"].ToString(),
                    EmailConfirmed = true,
                    IsTenant = false,
                    JobTitle = model.JobTitle,
                    MaritialStatus = model.MaritialStatus,
                    FullName = model.FullName,
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.MobileNumber,
                    PhoneNumberConfirmed = true,
                };
                var result = await _userManager.CreateAsync(user, TempData["Password"].ToString());
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View(model);
        }
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region AccessDenied
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAllGouvernrateCities(int gouvernrteId)
        {
            var allcities = await _unityOfWork.City.FindAllAsync(x => !x.IsDeleted && x.GovernurateId == gouvernrteId);
            return new JsonResult(new { Succeded = true, Message = "", Content = allcities });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFacultiesByUniversityId(int universityId)
        {
            var allfaculties = await _unityOfWork.Fuclty.FindAllAsync(x => !x.IsDeleted && x.UniversityId == universityId);
            return new JsonResult(new { Succeded = true, Message = "", Content = allfaculties });
        }
    }
}
