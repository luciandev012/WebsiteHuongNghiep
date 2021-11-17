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
    public class ManageMbtiTableServices : IManageMbtiTableServices
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageMbtiTableServices(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(MbtiTable request)
        {
            await _context.AddAsync(request);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var bmti = await _context.MbtiTables.FindAsync(id);
            _context.Remove(bmti);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(MbtiTable request)
        {
            var mbti = await _context.MbtiTables.FindAsync(request.Id);
            mbti.Question = request.Question;
            mbti.AnswerA = request.AnswerA;
            mbti.AnswerB = request.AnswerB;
            mbti.Position = request.Position;
            return await _context.SaveChangesAsync();
        }

        public async Task<MbtiTable> GetMbtiTableById(int id)
        {
            return await _context.MbtiTables.FindAsync(id);
        }

        public async Task<List<MbtiTable>> GetMbtiTables()
        {
            return await _context.MbtiTables.ToListAsync();
        }
    }
}
