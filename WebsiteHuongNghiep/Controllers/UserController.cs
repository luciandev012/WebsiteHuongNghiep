using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebsiteHuongNghiep.Application.Request;
using WebsiteHuongNghiep.Application.Services.System;

namespace WebsiteHuongNghiep.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            var result = await _userServices.Authenticate(request);
            if (!result.Success)
            {
                ModelState.AddModelError("CustomError", result.Message);
                return new RedirectResult(Url.Action("Index") + HttpUtility.UrlDecode("#about"));
                //return View("Index#about");
                //return RedirectToPage("./Index#about"); 
            }
            var user = result.ResponseObj;
            HttpContext.Session.SetString("UserName", user.FirstName);
            return RedirectToAction("Index", "Home");


        }



    }
}
