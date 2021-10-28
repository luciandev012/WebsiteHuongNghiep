﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HollandMPController : Controller
    {
        private readonly IManageHLMultipleChoiceServices _manageHLMultipleChoice;
        private readonly IManageHLTableServices _manageHLTable;
        public HollandMPController(IManageHLMultipleChoiceServices manageHLMultipleChoice, IManageHLTableServices manageHLTable)
        {
            _manageHLMultipleChoice = manageHLMultipleChoice;
            _manageHLTable = manageHLTable;
        }
        public async Task<IActionResult> Index(int? tableId)
        {
            var hlMultiples = await _manageHLMultipleChoice.GetAll();
            if (tableId.HasValue)
            {
                hlMultiples = await _manageHLMultipleChoice.GetByTable(tableId.Value);
            }
            var tables = await _manageHLTable.GetAll();
            ViewBag.Tables = tables.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.HLTableId.ToString(),
                Selected = tableId.HasValue && tableId == x.HLTableId
            });
            return View(hlMultiples);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var hlTables = await _manageHLTable.GetAll();
            ViewBag.Tables = hlTables.Select(x => new SelectListItem() {
                Text = x.Name,
                Value = x.HLTableId.ToString(),
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HollandMultipleChoice request)
        {
            var result = await _manageHLMultipleChoice.Create(request);
            if(result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
    }
}
