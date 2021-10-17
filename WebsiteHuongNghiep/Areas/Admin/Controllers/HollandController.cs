using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HollandController : Controller
    {
        private readonly IManageHLTableServices _manageHLTable;
        public HollandController(IManageHLTableServices manageHLTable)
        {
            _manageHLTable = manageHLTable;
        }
        public async Task<IActionResult> Index()
        {
            var hlTables = await _manageHLTable.GetAll();
            return View(hlTables);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HollandTable request)
        {
            var result = await _manageHLTable.Create(request);
            if(result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var hlTbale = await _manageHLTable.GetById(id);
            return View(hlTbale);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HollandTable hlTable)
        {
            var result = await _manageHLTable.Update(hlTable);
            if(result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(hlTable);
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageHLTable.Delete(id);
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public async Task<IActionResult> Delete(HollandTable request)
        //{
        //    var result = await _manageHLTable.Delete(request.HLTableId);
        //    return RedirectToAction("Index");
        //}

    }
}
