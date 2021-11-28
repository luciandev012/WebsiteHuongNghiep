using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.Ennegram;
using WebsiteHuongNghiep.Controllers;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EnnegramController : BaseController
    {
        private readonly IManageEnnegramResult _manageEnnegramResult;
        public EnnegramController(IManageEnnegramResult manageEnnegramResult)
        {
            _manageEnnegramResult = manageEnnegramResult;
        }
        public async Task<IActionResult> Index(string keyword)
        {
            var egs = await _manageEnnegramResult.GetAll(keyword);
            ViewBag.Keyword = keyword;
            return View(egs);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EnnegramResult request)
        {
            var result = await _manageEnnegramResult.Create(request);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var egs = await _manageEnnegramResult.GetEnnegramResultById(id);
            return View(egs);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EnnegramResult request)
        {
            var result = await _manageEnnegramResult.Edit(request);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageEnnegramResult.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
