using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.MI;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Controllers
{
    public class MIController : BaseController
    {
        private readonly IManageMIQuestion _manageMIQuestion;
        private readonly IManageMITable _manageMITable;
        private readonly IManageMITracker _manageMITracker;
        public MIController(IManageMIQuestion manageMIQuestion, IManageMITable manageMITable, IManageMITracker manageMITracker)
        {
            _manageMIQuestion = manageMIQuestion;
            _manageMITable = manageMITable;
            _manageMITracker = manageMITracker;
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

            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            var tracker = new MITracker()
            {
                Result = result.ToString(),
                TimeStamp = DateTime.Now.ToString(),
                UserId = userId
            };
            await _manageMITracker.Create(tracker);

            return RedirectToAction("Result", new { id = result });
        }
        public async Task<IActionResult> Result(int id)
        {
            var table = await _manageMITable.GetMITableById(id);
            return View(table);
        }
    }
}
