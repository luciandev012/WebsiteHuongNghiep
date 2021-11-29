using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.MI;

namespace WebsiteHuongNghiep.Controllers
{
    public class MIController : Controller
    {
        private readonly IManageMIQuestion _manageMIQuestion;
        private readonly IManageMITable _manageMITable;
        public MIController(IManageMIQuestion manageMIQuestion, IManageMITable manageMITable)
        {
            _manageMIQuestion = manageMIQuestion;
            _manageMITable = manageMITable;
        }
        [HttpGet]
        public async Task<IActionResult> Make()
        {
            var mis = await _manageMIQuestion.GetAll("");
            return View(mis);
        }

        [HttpPost]
        public async Task<IActionResult> Make(int[] score, int[] tableId)
        {
            var result = await _manageMIQuestion.Execute(score, tableId);
            return RedirectToAction("Result", new { id = result });
        }
        public async Task<IActionResult> Result(int id)
        {
            var table = await _manageMITable.GetMITableById(id);
            return View(table);
        }
    }
}
