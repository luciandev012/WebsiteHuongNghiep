using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class MIQuestionController : BaseController
    {
        private readonly IManageMIQuestion _manageMIQuestion;
        private readonly IManageMITable _manageMITable;
        public MIQuestionController(IManageMIQuestion manageMIQuestion, IManageMITable manageMITable)
        {
            _manageMIQuestion = manageMIQuestion;
            _manageMITable = manageMITable;
        }
        public async Task<ActionResult> Index(string keyword)
        {
            var b5s = await _manageMIQuestion.GetAll(keyword);
            return View(b5s);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var mITables = await _manageMITable.GetAll("");
            ViewBag.MITables = mITables.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MIQuestion request)
        {
          

            var result = await _manageMIQuestion.Create(request);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var mi = await _manageMIQuestion.GetById(id);
            var mITables = await _manageMITable.GetAll("");
            ViewBag.MITables = mITables.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(mi);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MIQuestion request)
        {
            var result = await _manageMIQuestion.Edit(request);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageMIQuestion.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
