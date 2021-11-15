using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Details(int id)
        {
            var blogVM = await _manageBlogServices.GetBlogVMById(id);
            return View(blogVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _manageBlogServices.GetCategories();
            ViewBag.Categories = categories.Select(x => new SelectListItem() 
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(BlogRequest request, int categoryId)
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            request.CategoryId = categoryId;
            var result = await _manageBlogServices.Create(request, userId);
            if(result > 0)
            {
                return RedirectToAction("Index");

            }
            var categories = await _manageBlogServices.GetCategories();
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = (!string.IsNullOrEmpty(categoryId.ToString())) && categoryId == x.Id
            });
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _manageBlogServices.GetBlogById(id);
            var categories = await _manageBlogServices.GetCategories();
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = (!string.IsNullOrEmpty(blog.CategoryId.ToString())) && blog.CategoryId == x.Id
            });
            var blogRequest = new BlogRequest()
            {
                Id = blog.Id,
                Content = blog.Content,
                //CategoryId = blog.CategoryId,
                //Image = blog.Image,
                Name = blog.Name,
                Title = blog.Title
            };
            return View(blogRequest);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(BlogRequest request, int categoryId)
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            request.CategoryId = categoryId;
            var result = await _manageBlogServices.Edit(request.Id, request, userId);
            if (result > 0)
            {
                return RedirectToAction("Index");

            }
            var categories = await _manageBlogServices.GetCategories();
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = (!string.IsNullOrEmpty(categoryId.ToString())) && categoryId == x.Id
            });
            return View(request);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageBlogServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
