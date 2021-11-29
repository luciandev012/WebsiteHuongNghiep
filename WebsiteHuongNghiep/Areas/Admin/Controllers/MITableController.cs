using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.MI;
using WebsiteHuongNghiep.Controllers;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MITableController : BaseController
    {
        private readonly IManageMITable _manageMITable;
        public MITableController(IManageMITable manageMITable)
        {
            _manageMITable = manageMITable;
        }
        public async Task<ActionResult> Index(string keyword)
        {
            var b5s = await _manageMITable.GetAll(keyword);
            return View(b5s);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MITable request)
        {
            var result = await _manageMITable.Create(request);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var b5 = await _manageMITable.GetMITableById(id);
            return View(b5);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MITable request)
        {
            var result = await _manageMITable.Edit(request);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageMITable.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
