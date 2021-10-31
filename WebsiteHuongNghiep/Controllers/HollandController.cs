using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;

namespace WebsiteHuongNghiep.Controllers
{
    public class HollandController : BaseController
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
        [HttpGet]
        public async Task<IActionResult> Make(int id)
        {
            if (id == 0) id = 1;
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
                        
            
            return RedirectToAction("Make", new { id = id + 1 });
        }
    }
}
