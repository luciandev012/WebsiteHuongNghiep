using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;
using WebsiteHuongNghiep.Application.Services.BigFive;
using WebsiteHuongNghiep.Application.Services.MBTI;

namespace WebsiteHuongNghiep.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManageHLTrackerServices _manageHLTrackerServices;
        private readonly IManageMbtiTrackerServices _manageMbtiTrackerServices;
        private readonly IManageBFTracker _manageBFTracker;
        public HomeController(IManageHLTrackerServices manageHLTrackerServices, IManageMbtiTrackerServices manageMbtiTrackerServices, 
            IManageBFTracker manageBFTracker)
        {
            _manageHLTrackerServices = manageHLTrackerServices;
            _manageMbtiTrackerServices = manageMbtiTrackerServices;
            _manageBFTracker = manageBFTracker;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.HollandCount = await _manageHLTrackerServices.CountAllTrackers();
            ViewBag.MbtiCount = await _manageMbtiTrackerServices.CountTracker();
            ViewBag.BFCount = await _manageBFTracker.CountTracker();
            return View();
        }

    }
}
