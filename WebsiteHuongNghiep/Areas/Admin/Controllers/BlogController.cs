using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Request;
using WebsiteHuongNghiep.Application.Services.BlogService;
using WebsiteHuongNghiep.Controllers;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : BaseController
    {
        private readonly IManageBlogServices _manageBlogServices;
        public BlogController(IManageBlogServices manageBlogServices)
        {
            _manageBlogServices = manageBlogServices;
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _manageBlogServices.GetAllBlog();
            return View(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(BlogRequest request)
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            var result = await _manageBlogServices.Create(request, userId);
            if(result > 0)
            {
                return RedirectToAction("Index");

            }
            return View(request);
        }
    }
}
