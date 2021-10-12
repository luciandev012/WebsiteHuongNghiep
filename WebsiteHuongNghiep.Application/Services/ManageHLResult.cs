using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services
{
    public class ManageHLResult : IManageHLResultServices
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageHLResult(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(HollandResult request)
        {
            var hlResult = new HollandResult()
            {
                Result = request.Result,
                Table = request.Table
            };
            await _context.HollandResults.AddAsync(hlResult);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var hlResult = await _context.HollandResults.FindAsync(id);
            _context.HollandResults.Remove(hlResult);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(HollandResult request)
        {
            var hlResult = await _context.HollandResults.FindAsync(request.Id);
            hlResult.Result = request.Result;
            hlResult.Table = request.Table;
            return await _context.SaveChangesAsync();
        }
    }
}
