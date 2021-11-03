using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Controllers;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    public class HollandResultController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
