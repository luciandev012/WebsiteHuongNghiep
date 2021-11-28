using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.Ennegram
{
    public class ManageEGTracker : IManageEGTracker
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageEGTracker(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> CountTracker()
        {
            return await _context.EnnegramTrackers.CountAsync();
        }

        public async Task<int> CountTrackerByResult(string resultCode)
        {
            return await _context.EnnegramTrackers.Where(x => x.Result == resultCode).CountAsync();
        }

        public async Task<int> CountUser()
        {
            return await _context.EnnegramTrackers.GroupBy(x => x.UserId).CountAsync();
        }

        public async Task<int> Create(EnnegramTracker tracker)
        {
            await _context.EnnegramTrackers.AddAsync(tracker);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TrackerVM>> GetAll()
        {
            var mbtis = await _context.EnnegramTrackers.ToListAsync();
            var trackers = new List<TrackerVM>();
            foreach (var item in mbtis)
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

        public async Task<List<EnnegramTracker>> GetTrackerByUserId(Guid userId)
        {
            return await _context.EnnegramTrackers.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
