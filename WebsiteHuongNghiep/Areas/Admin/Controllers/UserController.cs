using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Request;
using WebsiteHuongNghiep.Application.Services.System;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public async Task<IActionResult> Index(string phoneNumber)
        {
            var users = await _userServices.GetUser(phoneNumber);
            ViewBag.PhoneNumber = phoneNumber;
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userServices.GetUserById(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            user.SecurityStamp = Guid.NewGuid().ToString();
            var result = await _userServices.Edit(user.Id, user);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request, string username)
        {
            request.PhoneNumber = username;
            var result = await _userServices.Register(request);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            var user = new User()
            {
                UserName = request.PhoneNumber,
                LastName = request.LastName,
                FirstName = request.FirstName,

            };
            return View(user);
        }
        
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userServices.Delete(id);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _userServices.GetUserById(id);
            return View(user);
        }

    }
}
