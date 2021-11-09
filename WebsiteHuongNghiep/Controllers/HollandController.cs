using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;
using WebsiteHuongNghiep.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebsiteHuongNghiep.Controllers
{
    
    public class HollandController : BaseController
    {

        private readonly IManageHLMultipleChoiceServices _manageHLMultipleChoiceServices;
        private readonly IManageHLTrackerServices _manageHLTrackerServices;
        private readonly IManageHLScoreServices _manageHLScoreServices;
        private readonly IManageHLTableServices _manageHLTableServices;
        private readonly IManageHLResultServices _manageHLResultServices;
        public HollandController(IManageHLMultipleChoiceServices manageHLMultipleChoiceServices, IManageHLTableServices manageHLTableServices,
            IManageHLTrackerServices manageHLTrackerServices, IManageHLScoreServices manageHLScoreServices,
            IManageHLResultServices manageHLResultServices)
        {
            _manageHLMultipleChoiceServices = manageHLMultipleChoiceServices;
            _manageHLTrackerServices = manageHLTrackerServices;
            _manageHLScoreServices = manageHLScoreServices;
            _manageHLTableServices = manageHLTableServices;
            _manageHLResultServices = manageHLResultServices;
        }
        public async Task<IActionResult> Index()
        {
            
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            
            //init tracker if not exist
            if (!await _manageHLTrackerServices.IsUserExist(userId) || await _manageHLTrackerServices.GetTrackerByUserId(userId) == null)
            {
                var tracker = new HollandTracker()
                {
                    Step = 1,
                    Times = 0,
                    TimeStamp = DateTime.Now.ToString(),
                    UserId = userId
                };
                await _manageHLTrackerServices.Create(tracker);
            }
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Make()
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            if (!await _manageHLTrackerServices.IsUserExist(userId) || (await _manageHLTrackerServices.GetTrackerByUserId(userId) == null))
            {
                return RedirectToAction("Index");
            }

            var tracker = await _manageHLTrackerServices.GetTrackerByUserId(userId);
            var id = tracker.Step; //show the current table which user is testing.

            var listQ = await _manageHLMultipleChoiceServices.GetByTable(id);
            int index = 1;
            foreach (var item in listQ)
            {
                item.Id = index;
                index++;
            }
            ViewBag.TableName = listQ[0].Table;
            ViewBag.Id = id;
            return View(listQ);
        }



        [HttpPost]
        public async Task<IActionResult> Make(int id, string[] data)
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            var tracker = await _manageHLTrackerServices.GetTrackerByUserId(userId);

            int score = 0;
            foreach(var item in data)
            {
                score += int.Parse(item);
            }

            // insert HL score
            await _manageHLScoreServices.Create(new HollandScore() 
            {
                Table = id,
                Score = score,
                TimeStamp = tracker.TimeStamp
            });

            var tables = await _manageHLTableServices.GetAll();
            if(tracker.Step < tables.Count - 3)
            {
                await _manageHLTrackerServices.IncreaseStep(tracker);
                return RedirectToAction("Make");
            }
            
            return RedirectToAction("Result");
        }

        public async Task<IActionResult> Result(int id)
        {
            if(id == 0)
            {
                var userId = new Guid(HttpContext.Session.GetString("UserId"));
                var tracker = await _manageHLTrackerServices.GetTrackerByUserId(userId);

                var hlScores = await _manageHLScoreServices.GetHollandScoresByTimeStamp(tracker.TimeStamp);
                var maxScore = hlScores.Max(x => x.Score);
                var rs = hlScores.Where(x => x.Score == maxScore).Select(x => x.Table).FirstOrDefault();
                var hlResut = await _manageHLResultServices.GetHollandResultByTable(rs);

                // update hlTracker
                await _manageHLTrackerServices.ReverseTimes(tracker);
                await _manageHLTrackerServices.SetFinalTable(tracker.Id, rs);

                return View(hlResut);
            }
            else
            {
                var tracker = await _manageHLTrackerServices.GetTrackerById(id);
                var hlResult = await _manageHLResultServices.GetHollandResultByTable(tracker.FinalTable);

                return View(hlResult);
            }
                
           
        }
    }
}
