﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Services;
using WebsiteHuongNghiep.Application.Services.BigFive;
using WebsiteHuongNghiep.Application.Services.Ennegram;
using WebsiteHuongNghiep.Application.Services.MBTI;
using WebsiteHuongNghiep.Application.Services.MI;
using WebsiteHuongNghiep.Application.ViewModels;

namespace WebsiteHuongNghiep.Controllers
{
    public class HistoryController : BaseController
    {
        private readonly IManageHLTrackerServices _manageHLTrackerServices;
        private readonly IManageMbtiTrackerServices _manageMbtiTrackerServices;
        private readonly IManageBFTracker _manageBFTracker;
        private readonly IManageEGTracker _manageEGTracker;
        private readonly IManageMITracker _manageMITracker;
        public HistoryController(IManageHLTrackerServices manageHLTrackerServices, IManageMbtiTrackerServices manageMbtiTrackerServices,
            IManageBFTracker manageBFTracker, IManageEGTracker manageEGTracker, IManageMITracker manageMITracker)
        {
            _manageMbtiTrackerServices = manageMbtiTrackerServices;
            _manageHLTrackerServices = manageHLTrackerServices;
            _manageBFTracker = manageBFTracker;
            _manageEGTracker = manageEGTracker;
            _manageMITracker = manageMITracker;
        }

        public async Task<IActionResult> Holland()
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            var trackers = await _manageHLTrackerServices.GetAllTrackersByUserId(userId);

            var trackersVM = new List<TrackerVM>();
            var totalTrackers = await _manageHLTrackerServices.CountAllTrackers();
            int index = 1;
            foreach(var item in trackers)
            {
                TrackerVM trackerVM = new TrackerVM()
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
        public async Task<IActionResult> Mbti()
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            var trackers = await _manageMbtiTrackerServices.GetTrackerByUserId(userId);

            var trackersVM = new List<TrackerVM>();
            var totalTrackers = await _manageMbtiTrackerServices.CountTracker();
            int index = 1;
            foreach (var item in trackers)
            {
                TrackerVM trackerVM = new TrackerVM()
                {
                    Id = item.Id,
                    Index = index,
                    TimeStamp = item.TimeStamp,
                    SameResultCount = await _manageMbtiTrackerServices.CountTrackerByFinalResult(item.FinalResult),
                    FinalResult = item.FinalResult
                };
                trackerVM.SameResultPercent = ((float)trackerVM.SameResultCount / totalTrackers) * 100;
                trackersVM.Add(trackerVM);
                index++;
            }
            return View(trackersVM);
        }
        public async Task<IActionResult> BigFive()
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            var trackers = await _manageBFTracker.GetTrackerByUserId(userId);

            var trackersVM = new List<TrackerVM>();
            var totalTrackers = await _manageBFTracker.CountTracker();
            int index = 1;
            foreach (var item in trackers)
            {
                TrackerVM trackerVM = new TrackerVM()
                {
                    Id = item.Id,
                    Index = index,
                    TimeStamp = item.TimeStamp,
                    SameResultCount = await _manageBFTracker.CountTrackerByResult(item.ResultId),
                    FinalResult = item.ResultId.ToString()
                };
                trackerVM.SameResultPercent = ((float)trackerVM.SameResultCount / totalTrackers) * 100;
                trackersVM.Add(trackerVM);
                index++;
            }
            return View(trackersVM);
        }
        public async Task<IActionResult> Ennegram()
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            var trackers = await _manageEGTracker.GetTrackerByUserId(userId);

            var trackersVM = new List<TrackerVM>();
            var totalTrackers = await _manageEGTracker.CountTracker();
            int index = 1;
            foreach (var item in trackers)
            {
                TrackerVM trackerVM = new TrackerVM()
                {
                    Id = item.Id,
                    Index = index,
                    TimeStamp = item.TimeStamp,
                    SameResultCount = await _manageEGTracker.CountTrackerByResult(item.Result),
                    FinalResult = item.Result
                };
                trackerVM.SameResultPercent = ((float)trackerVM.SameResultCount / totalTrackers) * 100;
                trackersVM.Add(trackerVM);
                index++;
            }
            return View(trackersVM);
        }

        public async Task<IActionResult> MI()
        {
            var userId = new Guid(HttpContext.Session.GetString("UserId"));
            var trackers = await _manageMITracker.GetTrackerByUserId(userId);

            var trackersVM = new List<TrackerVM>();
            var totalTrackers = await _manageMITracker.CountTracker();
            int index = 1;
            foreach (var item in trackers)
            {
                TrackerVM trackerVM = new TrackerVM()
                {
                    Id = item.Id,
                    Index = index,
                    TimeStamp = item.TimeStamp,
                    SameResultCount = await _manageMITracker.CountTrackerByResult(item.Result),
                    FinalResult = item.Result
                };
                trackerVM.SameResultPercent = ((float)trackerVM.SameResultCount / totalTrackers) * 100;
                trackersVM.Add(trackerVM);
                index++;
            }
            return View(trackersVM);
        }
    }
}
