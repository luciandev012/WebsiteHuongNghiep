﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.MBTI
{
    public class ManageMbtiTrackerService : IManageMbtiTrackerServices
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageMbtiTrackerService(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task Create(string finalResult, string timeStamp, Guid userId)
        {
            var request = new MbtiTracker()
            {
                FinalResult = finalResult,
                TimeStamp = timeStamp,
                UserId = userId
            };
            var result = await _context.MbtiTrackers.AddAsync(request);
            await _context.SaveChangesAsync();
        }
        public async Task<int> CountTracker()
        {
            return await _context.MbtiTrackers.CountAsync();
        }
        public async Task<List<MbtiTracker>> GetTrackerByUserId(Guid userId)
        {

            return await _context.MbtiTrackers.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task<int> CountTrackerByFinalResult(string finalResult)
        {
            return await _context.MbtiTrackers.Where(x => x.FinalResult == finalResult).CountAsync();
        }

    }
}