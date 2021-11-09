using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;
using WebsiteHuongNghiep.Application.ViewModels;

namespace WebsiteHuongNghiep.Controllers
{
    public class HistoryController : BaseController
    {
        private readonly IManageHLTrackerServices _manageHLTrackerServices;
        public HistoryController(IManageHLTrackerServices manageHLTrackerServices)
        {
            _manageHLTrackerServices = manageHLTrackerServices;
        }

        public async Task<IActionResult> Holland()
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            var trackers = await _manageHLTrackerServices.GetAllTrackersByUserId(userId);

            var trackersVM = new List<HollandTrackerVM>();
            var totalTrackers = await _manageHLTrackerServices.CountAllTrackers();
            int index = 1;
            foreach(var item in trackers)
            {
                HollandTrackerVM trackerVM = new HollandTrackerVM()
                {
                    Id = item.Id,
                    Index = index,
                    TimeStamp = item.TimeStamp,
                    SameResultCount = await _manageHLTrackerServices.CountTrackersByFinalTable(item.FinalTable)
                };
                trackerVM.SameResultPercent = ((float)trackerVM.SameResultCount / totalTrackers) * 100;
                trackersVM.Add(trackerVM);
                index++;
            }    
            return View(trackersVM);
        }
    }
}
