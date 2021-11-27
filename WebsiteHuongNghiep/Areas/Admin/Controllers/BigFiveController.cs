using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.BigFive;
using WebsiteHuongNghiep.Controllers;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BigFiveController : BaseController
    {
        private readonly IManageBFResult _manageBFResult;
        public BigFiveController(IManageBFResult manageBFResult)
        {
            _manageBFResult = manageBFResult;
        }
        public async Task<ActionResult> Index(string keyword)
        {
            var b5s = await _manageBFResult.GetAll(keyword);
            return View(b5s);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BigFiveResult request)
        {
            var result = await _manageBFResult.Create(request);
            if(result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var b5 = await _manageBFResult.GetBigFiveResultById(id);
            return View(b5);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BigFiveResult request)
        {
            var result = await _manageBFResult.Edit(request);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageBFResult.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
