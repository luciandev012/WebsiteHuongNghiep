using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;

namespace WebsiteHuongNghiep.Controllers
{
    public class HollandController : Controller
    {

        private readonly IManageHLMultipleChoiceServices _manageHLMultipleChoiceServices;
        public HollandController(IManageHLMultipleChoiceServices manageHLMultipleChoiceServices)
        {
            _manageHLMultipleChoiceServices = manageHLMultipleChoiceServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Make(int id)
        {
            var listQ = await _manageHLMultipleChoiceServices.GetByTable(id);
            foreach(var item in listQ)
            {
                item.Id = item.Id - 9 * (id - 1);
            }
            ViewBag.TableName = listQ[0].Table;
            return View(listQ);
        }
    }
}
