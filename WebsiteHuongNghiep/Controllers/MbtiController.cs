using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.MBTI;


namespace WebsiteHuongNghiep.Controllers
{
    public class MbtiController : BaseController
    {
        private readonly IManageMbtiTableServices _manageMbtiTableServices;
        private readonly IManageMbtiTrackerServices _manageMbtiTrackerServices;
        public MbtiController(IManageMbtiTableServices manageMbtiTableServices, IManageMbtiTrackerServices manageMbtiTrackerServices)
        {
            _manageMbtiTableServices = manageMbtiTableServices;
            _manageMbtiTrackerServices = manageMbtiTrackerServices;
        }
        public async Task<IActionResult> Index()
        {
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Make()
        {
            var mbtis = await _manageMbtiTableServices.GetMbtiTables();
            return View(mbtis);
        }
        [HttpPost]
        public async Task<IActionResult> Make(string[] score)
        {

            int[] inputScore = new int[score.Length];
            for(int i = 0; i < score.Length; i++)
            {
                inputScore[i] = int.Parse(score[i]);
            }
            var result = await _manageMbtiTableServices.GetResult(inputScore);
            if(result != null)
            {
                var userId = new Guid(HttpContext.Session.GetString("UserId"));
                await _manageMbtiTrackerServices.Create(result, DateTime.Now.ToString(), userId);
            }    
            return RedirectToAction("Result", new { result = result });
        }
        [HttpGet]
        public async Task<IActionResult> Result(string result)
        {
            var finalResult = await _manageMbtiTableServices.GetMbtiResult(result);
            return View(finalResult);
        }
    }
}
