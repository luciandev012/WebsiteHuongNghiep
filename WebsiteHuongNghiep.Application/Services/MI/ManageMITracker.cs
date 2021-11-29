using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.MI
{
    public class ManageMITracker : IManageMITracker
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageMITracker(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> CountTracker()
        {
            return await _context.MITrackers.CountAsync();
        }

        public async Task<int> CountTrackerByResult(string resultId)
        {
            return await _context.MITrackers.Where(x => x.Result == resultId.ToString()).CountAsync();
        }

        public async Task<int> CountUser()
        {
            return await _context.MITrackers.GroupBy(x => x.UserId).CountAsync();
        }

        public async Task<int> Create(MITracker tracker)
        {
            await _context.MITrackers.AddAsync(tracker);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TrackerVM>> GetAll()
        {
            var mis = await _context.MITrackers.ToListAsync();
            var trackers = new List<TrackerVM>();
            foreach (var item in mis)
            {
                var tracker = new TrackerVM()
                {
                    Id = item.Id,
                    FinalResult = item.Result.ToString(),
                    TimeStamp = item.TimeStamp,
                    Username = (await _context.Users.Where(x => x.Id == item.UserId).FirstOrDefaultAsync()).FirstName + " "
                                + (await _context.Users.Where(x => x.Id == item.UserId).FirstOrDefaultAsync()).LastName,
                };
                trackers.Add(tracker);
            }
            return trackers;
        }

        public async Task<List<MITracker>> GetTrackerByUserId(Guid userId)
        {
            return await _context.MITrackers.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
