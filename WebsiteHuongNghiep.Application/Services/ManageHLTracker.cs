using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> IsUserExist(Guid userId)
        {
            var tracker = await _context.HollandTrackers.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            return tracker != null;
        }
        public async Task<HollandTracker> GetTrackerByUserId(Guid userId)
        {
            return await _context.HollandTrackers.Where(x => x.UserId == userId && x.Times == 0).FirstOrDefaultAsync();
        }
        public async Task<int> IncreaseStep(HollandTracker tracker)
        {
            var hlTracker = await _context.HollandTrackers.Where(x => x.TimeStamp == tracker.TimeStamp && x.UserId == tracker.UserId)
                                    .FirstOrDefaultAsync();
            if(hlTracker == null)
            {
                return -1;
            }
            hlTracker.Step++;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> ReverseTimes(HollandTracker tracker)
        {
            var hlTracker = await _context.HollandTrackers.Where(x => x.TimeStamp == tracker.TimeStamp && x.UserId == tracker.UserId)
                                    .FirstOrDefaultAsync();
            if (hlTracker == null)
            {
                return -1;
            }
            
            if(hlTracker.Times == 0)
            {
                hlTracker.Times = 1;
            }
            else
            {
                hlTracker.Times = 0;
            }
            return await _context.SaveChangesAsync();
        }
        public async Task SetFinalTable(int id, int tableId)
        {
            var hlTracker = await _context.HollandTrackers.FindAsync(id);
            hlTracker.FinalTable = tableId;
            await _context.SaveChangesAsync();
        }
        public async Task<List<HollandTracker>> GetAllTrackersByUserId(Guid userId)
        {
            return await _context.HollandTrackers.Where(x => x.UserId == userId && x.Times == 1).ToListAsync();
        }
        public async Task<HollandTracker> GetTrackerById(int id)
        {
            return await _context.HollandTrackers.FindAsync(id);
        }
        public async Task<int> CountAllTrackers()
        {
            return await _context.HollandTrackers.Where(x => x.Times == 1).CountAsync();
        }
        public async Task<int> CountTrackersByFinalTable(int finalTable)
        {
            var rs = await _context.HollandTrackers.Where(x => x.FinalTable == finalTable).CountAsync();
            return rs;
        }
    }
}
