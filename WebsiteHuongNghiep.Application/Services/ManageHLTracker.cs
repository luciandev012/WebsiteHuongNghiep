using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services
{
    public class ManageHLTracker : IManageHLTrackerServices
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageHLTracker(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(HollandTracker request)
        {
            var hlTracker = new HollandTracker()
            {
                Step = request.Step,
                Times = request.Times,
                TimeStamp = request.TimeStamp,
                UserId = request.UserId
            };
            await _context.HollandTrackers.AddAsync(hlTracker);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var hlTracker = await _context.HollandTrackers.FindAsync(id);
            _context.HollandTrackers.Remove(hlTracker);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(HollandTracker request)
        {
            var hlTracker = await _context.HollandTrackers.FindAsync(request.Id);
            hlTracker.Step = request.Step;
            hlTracker.Times = request.Times;
            hlTracker.TimeStamp = request.TimeStamp;
            return await _context.SaveChangesAsync();
        }
    }
}
