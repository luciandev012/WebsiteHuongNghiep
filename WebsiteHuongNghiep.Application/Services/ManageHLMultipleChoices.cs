using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services
{
    public class ManageHLMultipleChoices : IManageHLMultipleChoiceServices
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageHLMultipleChoices(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(HollandMultipleChoice request)
        {
            var hlMultipleChoice = new HollandMultipleChoice()
            {
                Question = request.Question,
                HLTableId = request.HLTableId
            };
            await _context.HollandMultipleChoices.AddAsync(hlMultipleChoice);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var hlMultipleChoice = await _context.HollandMultipleChoices.FindAsync(id);
            _context.HollandMultipleChoices.Remove(hlMultipleChoice);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<MultipleChoicesVM>> GetAll()
        {
            var query = from m in _context.HollandMultipleChoices
                        join t in _context.HollandTables on m.HLTableId equals t.HLTableId
                        select new { m, t };
            var data = await query.Select(x => new MultipleChoicesVM()
            {
                Id = x.m.Id,
                Question = x.m.Question,
                Table = x.t.Name
            }).ToListAsync();

            return data;
        }

        public async Task<MultipleChoicesVM> GetById(int id)
        {
            var hlMultiple = await _context.HollandMultipleChoices.FindAsync(id);
            var hlTable = await _context.HollandTables.FindAsync(hlMultiple.HLTableId);
            return new MultipleChoicesVM()
            {
                Id = hlMultiple.Id,
                Question = hlMultiple.Question,
                Table = hlTable.Name
            };
        }

        public async Task<int> Update(HollandMultipleChoice request)
        {
            var hlMultipleChoice = await _context.HollandMultipleChoices.FindAsync(request.Id);
            hlMultipleChoice.Question = request.Question;
            hlMultipleChoice.HLTableId = request.HLTableId;
            return await _context.SaveChangesAsync();
        }
    }
}
