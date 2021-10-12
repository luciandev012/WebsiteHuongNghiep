using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services
{
    public class ManageHLScore : IManageHLScoreServices
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageHLScore(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(HollandScore request)
        {
            var hlScore = new HollandScore()
            {
                Score = request.Score,
                Table = request.Table,
                TimeStamp = request.TimeStamp
            };
            await _context.HollandScores.AddAsync(hlScore);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var hlScore = await _context.HollandScores.FindAsync(id);
            _context.HollandScores.Remove(hlScore);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(HollandScore request)
        {
            var hlScore = await _context.HollandScores.FindAsync(request.Id);
            hlScore.Score = request.Score;
            hlScore.Table = request.Table;
            hlScore.TimeStamp = request.TimeStamp;
            return await _context.SaveChangesAsync();
        }
    }
}
