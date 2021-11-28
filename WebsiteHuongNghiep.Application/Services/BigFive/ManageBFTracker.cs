using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.BigFive
{
    public class ManageBFTracker : IManageBFTracker
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageBFTracker(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> CountTracker()
        {
            return await _context.BigFiveTrackers.CountAsync();
        }

        public async Task<int> CountTrackerByResult(int result)
        {
            return await _context.BigFiveTrackers.Where(x => x.ResultId == result).CountAsync();
        }

        public async Task<int> CountUser()
        {
            return await _context.BigFiveTrackers.GroupBy(x => x.UserId).CountAsync();
        }

        public async Task<int> Create(BigFiveTracker tracker)
        {
            await _context.BigFiveTrackers.AddAsync(tracker);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TrackerVM>> GetAll()
        {
            var b5s = await _context.BigFiveTrackers.ToListAsync();
            var trackers = new List<TrackerVM>();
            foreach (var item in b5s)
            {
                var tracker = new TrackerVM()
                {
                    Id = item.Id,
                    FinalResult = item.ResultId.ToString(),
                    TimeStamp = item.TimeStamp,
                    Username = (await _context.Users.Where(x => x.Id == item.UserId).FirstOrDefaultAsync()).FirstName + " "
                                + (await _context.Users.Where(x => x.Id == item.UserId).FirstOrDefaultAsync()).LastName,
                };
                trackers.Add(tracker);
            }
            return trackers;
        }

        public async Task<List<BigFiveTracker>> GetTrackerByUserId(Guid userId)
        {
            return await _context.BigFiveTrackers.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
