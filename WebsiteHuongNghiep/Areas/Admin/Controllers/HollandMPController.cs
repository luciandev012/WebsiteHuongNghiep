using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;

namespace WebsiteHuongNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HollandMPController : Controller
    {
        private readonly IManageHLMultipleChoiceServices _manageHLMultipleChoice;
        public HollandMPController(IManageHLMultipleChoiceServices manageHLMultipleChoice)
        {
            _manageHLMultipleChoice = manageHLMultipleChoice;
        }
        public async Task<IActionResult> Index()
        {
            var hlMultiples = await _manageHLMultipleChoice.GetAll();
            return View(hlMultiples);
        }
    }
}
