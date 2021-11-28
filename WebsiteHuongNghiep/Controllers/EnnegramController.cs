using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services.Ennegram;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Controllers
{
    public class EnnegramController : BaseController
    {
        private readonly IManageEnnegramResult _manageEnnegramResult;
        private readonly IManageEGTracker _manageEGTracker;
        public EnnegramController(IManageEnnegramResult manageEnnegramResult, IManageEGTracker manageEGTracker)
        {
            _manageEnnegramResult = manageEnnegramResult;
            _manageEGTracker = manageEGTracker;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Make()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Make(string resultCode)
        {
            //var result = await _manageEnnegramResult.GetEnnegramResultByResultCode(resultCode);
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            var tracker = new EnnegramTracker()
            {
                Result = resultCode,
                TimeStamp = DateTime.Now.ToString(),
                UserId = userId
            };
            await _manageEGTracker.Create(tracker);

            return RedirectToAction("Result", new { resultCode = resultCode });
        }
        public async Task<IActionResult> Result(string resultCode)
        {
            var result = await _manageEnnegramResult.GetEnnegramResultByResultCode(resultCode);
            return View(result);
        }
    }
}
