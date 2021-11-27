using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.BigFive;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BigFiveQuestionController : Controller
    {
        private readonly IManageBFQuestion _manageBFQuestion;
        private readonly IManageBFResult _manageBFResult;
        public BigFiveQuestionController(IManageBFQuestion manageBFQuestion, IManageBFResult manageBFResult)
        {
            _manageBFQuestion = manageBFQuestion;
            _manageBFResult = manageBFResult;
        }
        public async Task<ActionResult> Index(string keyword)
        {
            var b5s = await _manageBFQuestion.GetAll(keyword);
            return View(b5s);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var b5result = await _manageBFResult.GetAll("");
            ViewBag.B5Results = b5result.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BigFiveQuestion request)
        {
            var result = await _manageBFQuestion.Create(request);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var b5 = await _manageBFQuestion.GetBigFiveQuestionById(id);
            var b5result = await _manageBFResult.GetAll("");
            ViewBag.B5Results = b5result.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(b5);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BigFiveQuestion request)
        {
            var result = await _manageBFQuestion.Edit(request);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageBFQuestion.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
