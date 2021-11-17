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
    public class MbtiTableController : Controller
    {
        private readonly IManageMbtiTableServices _manageMbtiTableServices;
        public MbtiTableController(IManageMbtiTableServices manageMbtiTableServices)
        {
            _manageMbtiTableServices = manageMbtiTableServices;
        }
        public async Task<IActionResult> Index()
        {
            var mbtis = await _manageMbtiTableServices.GetMbtiTables();
            return View(mbtis);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MbtiTable request)
        {
            var result = await _manageMbtiTableServices.Create(request);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var mbti = await _manageMbtiTableServices.GetMbtiTableById(id);
            return View(mbti);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MbtiTable request)
        {
            var result = await _manageMbtiTableServices.Edit(request);
            if(result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageMbtiTableServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
