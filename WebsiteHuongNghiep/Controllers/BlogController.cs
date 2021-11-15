using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.BlogService;

namespace WebsiteHuongNghiep.Controllers
{
    public class BlogController : Controller
    {
        private readonly IManageBlogServices _manageBlogServices;
        //private readonly 
        public BlogController(IManageBlogServices manageBlogServices)
        {
            _manageBlogServices = manageBlogServices;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1)
        {
            var blogs = await _manageBlogServices.GetBlogPaging(keyword, pageIndex);
            ViewBag.Keyword = keyword;
            //ViewBag.ContentFolder = 
            return View(blogs);
        }
        public async Task<IActionResult> Detail(string metaTitle)
        {
            var blog = await _manageBlogServices.GetBlogByMetaTitle(metaTitle);
            await _manageBlogServices.IncreaseViewCount(blog.Id);
            return View(blog);
        }
    }
}
