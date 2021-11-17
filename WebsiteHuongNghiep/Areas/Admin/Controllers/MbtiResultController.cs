using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.MBTI;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MbtiResultController : Controller
    {
        private readonly IManageMbtiResultServices _manageMbtiResultServices;
        public MbtiResultController(IManageMbtiResultServices manageMbtiResultServices)
        {
            _manageMbtiResultServices = manageMbtiResultServices;
        }
        public async Task<IActionResult> Index(string keyword)
        {
            var mbtiResults = await _manageMbtiResultServices.GetAll(keyword);
            ViewBag.Keyword = keyword;
            return View(mbtiResults);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MbtiResult request)
        {
            var result = await _manageMbtiResultServices.Create(request);
            if(result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var mbtiResult = await _manageMbtiResultServices.GetMbtiResultById(id);
            return View(mbtiResult);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MbtiResult request)
        {
            var result = await _manageMbtiResultServices.Edit(request);
            if(result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _manageMbtiResultServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
