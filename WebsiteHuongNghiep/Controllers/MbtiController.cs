using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.MBTI;

namespace WebsiteHuongNghiep.Controllers
{
    public class MbtiController : Controller
    {
        private readonly IManageMbtiTableServices _manageMbtiTableServices;
        public MbtiController(IManageMbtiTableServices manageMbtiTableServices)
        {
            _manageMbtiTableServices = manageMbtiTableServices;
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
    }
}
