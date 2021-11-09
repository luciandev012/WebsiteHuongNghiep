using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;

namespace WebsiteHuongNghiep.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManageHLTrackerServices _manageHLTrackerServices;
        public HomeController(IManageHLTrackerServices manageHLTrackerServices)
        {
            _manageHLTrackerServices = manageHLTrackerServices;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.HollandCount = await _manageHLTrackerServices.CountAllTrackers();
            return View();
        }

    }
}
