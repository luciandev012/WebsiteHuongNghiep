using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;
using WebsiteHuongNghiep.Application.Services.MBTI;
using WebsiteHuongNghiep.Controllers;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        private readonly IManageHLTrackerServices _manageHLTrackerServices;
        private readonly IManageMbtiTrackerServices _manageMbtiTrackerServices;
        public HomeController(IManageHLTrackerServices manageHLTrackerServices, IManageMbtiTrackerServices manageMbtiTrackerServices)
        {
            _manageMbtiTrackerServices = manageMbtiTrackerServices;
            _manageHLTrackerServices = manageHLTrackerServices;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.HollandCount = await _manageHLTrackerServices.CountAllTrackers();
            ViewBag.HollandUserCount = await _manageHLTrackerServices.CountUser();
            ViewBag.MbtiCount = await _manageMbtiTrackerServices.CountTracker();
            ViewBag.MbtiUserCount = await _manageMbtiTrackerServices.CountUser();
            return View();
        }
        public async Task<IActionResult> Holland()
        {
            var hollands = await _manageHLTrackerServices.GetAll();
            
            return View(hollands);
        }
        public async Task<IActionResult> Mbti()
        {
            var mbtis = await _manageMbtiTrackerServices.GetAll();
            return View(mbtis);
        }
    }
}
