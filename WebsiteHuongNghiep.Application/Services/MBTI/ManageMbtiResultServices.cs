using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.MBTI
{
    public class ManageMbtiResultServices : IManageMbtiResultServices
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageMbtiResultServices(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(MbtiResult request)
        {
            await _context.MbtiResults.AddAsync(request);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var mbtiResult = await _context.MbtiResults.FindAsync(id);
            _context.MbtiResults.Remove(mbtiResult);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(MbtiResult request)
        {
            var mbtiResult = await _context.MbtiResults.FindAsync(request.Id);
            mbtiResult.FinalResult = request.FinalResult;
            mbtiResult.Explaination = request.Explaination;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<MbtiResult>> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            var mbtiResults = await _context.MbtiResults.Where(x => x.FinalResult.Contains(keyword)).ToListAsync();
            return mbtiResults;
        }

        public async Task<MbtiResult> GetMbtiResultById(int id)
        {
            return await _context.MbtiResults.FindAsync(id);
        }
    }
}
