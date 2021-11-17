using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;
using WebsiteHuongNghiep.Application.Services.MBTI;

namespace WebsiteHuongNghiep.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManageHLTrackerServices _manageHLTrackerServices;
        private readonly IManageMbtiTrackerServices _manageMbtiTrackerServices;
        public HomeController(IManageHLTrackerServices manageHLTrackerServices, IManageMbtiTrackerServices manageMbtiTrackerServices)
        {
            _manageHLTrackerServices = manageHLTrackerServices;
            _manageMbtiTrackerServices = manageMbtiTrackerServices;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.HollandCount = await _manageHLTrackerServices.CountAllTrackers();
            ViewBag.MbtiCount = await _manageMbtiTrackerServices.CountTracker();
            return View();
        }

    }
}
