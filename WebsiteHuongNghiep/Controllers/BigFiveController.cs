using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.BigFive;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Controllers
{
    public class BigFiveController : BaseController
    {
        private readonly IManageBFQuestion _manageBFQuestion;
        private readonly IManageBFResult _manageBFResult;
        private readonly IManageBFTracker _manageBFTracker;
        public BigFiveController(IManageBFQuestion manageBFQuestion, IManageBFResult manageBFResult, IManageBFTracker manageBFTracker)
        {
            _manageBFQuestion = manageBFQuestion;
            _manageBFResult = manageBFResult;
            _manageBFTracker = manageBFTracker;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Make()
        {
            var b5vms = await _manageBFQuestion.GetBigFiveVMs();

            return View(b5vms);
        }
        [HttpPost]
        public async Task<IActionResult> Make(string[] score, string[] resultId)
        {

            int[] scoreInt = new int[score.Length];
            int[] resultIdInt = new int[score.Length];
            for(int i = 0; i < score.Length; i++)
            {
                scoreInt[i] = int.Parse(score[i]);
                resultIdInt[i] = int.Parse(resultId[i]);
            }
            int result = await _manageBFQuestion.GetResult(scoreInt, resultIdInt);

            var userId = HttpContext.Session.GetString("UserId");
            var tracker = new BigFiveTracker()
            {
                ResultId = result,
                TimeStamp = DateTime.Now.ToString(),
                UserId = new Guid(userId)
            };
            await _manageBFTracker.Create(tracker);
            return RedirectToAction("Result", new {id = result});

        }
        public async Task<IActionResult> Result(int id)
        {
            var result = await _manageBFResult.GetBigFiveResultById(id);
            return View(result);
        }
    }
}
