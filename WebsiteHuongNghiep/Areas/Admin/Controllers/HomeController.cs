using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;
using WebsiteHuongNghiep.Application.Services.BigFive;
using WebsiteHuongNghiep.Application.Services.Ennegram;
using WebsiteHuongNghiep.Application.Services.MBTI;
using WebsiteHuongNghiep.Controllers;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        private readonly IManageHLTrackerServices _manageHLTrackerServices;
        private readonly IManageMbtiTrackerServices _manageMbtiTrackerServices;
        private readonly IManageBFTracker _manageBFTracker;
        private readonly IManageEGTracker _manageEGTracker;
        public HomeController(IManageHLTrackerServices manageHLTrackerServices, IManageMbtiTrackerServices manageMbtiTrackerServices,
            IManageBFTracker manageBFTracker, IManageEGTracker manageEGTracker)
        {
            _manageMbtiTrackerServices = manageMbtiTrackerServices;
            _manageHLTrackerServices = manageHLTrackerServices;
            _manageBFTracker = manageBFTracker;
            _manageEGTracker = manageEGTracker;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.HollandCount = await _manageHLTrackerServices.CountAllTrackers();
            ViewBag.HollandUserCount = await _manageHLTrackerServices.CountUser();
            ViewBag.MbtiCount = await _manageMbtiTrackerServices.CountTracker();
            ViewBag.MbtiUserCount = await _manageMbtiTrackerServices.CountUser();
            ViewBag.BFCount = await _manageBFTracker.CountTracker();
            ViewBag.BFUserCount = await _manageBFTracker.CountUser();
            ViewBag.EGCount = await _manageEGTracker.CountTracker();
            ViewBag.EGUserCount = await _manageEGTracker.CountUser();
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
        public async Task<IActionResult> BigFive()
        {
            var b5s = await _manageBFTracker.GetAll();
            return View(b5s);
        }
        public async Task<IActionResult> Ennegram()
        {
            var egs = await _manageEGTracker.GetAll();
            return View(egs);
        }
    }
}
