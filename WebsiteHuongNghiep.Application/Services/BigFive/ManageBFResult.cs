using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.BigFive
{
    public class ManageBFResult : IManageBFResult
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageBFResult(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(BigFiveResult request)
        {
            await _context.BigFiveResults.AddAsync(request);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var b5 = await _context.BigFiveResults.FindAsync(id);
            _context.Remove(b5);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(BigFiveResult request)
        {
            var b5 = await _context.BigFiveResults.FindAsync(request.Id);
            b5.Name = request.Name;
            b5.Result = request.Result;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<BigFiveResult>> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            var b5s = await _context.BigFiveResults.Where(x => x.Name.Contains(keyword)).ToListAsync();
            return b5s;
        }

        public async Task<BigFiveResult> GetBigFiveResultById(int id)
        {
            return await _context.BigFiveResults.FindAsync(id);
        }
    }
}
