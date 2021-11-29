using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.MI
{
    public class ManageMITable : IManageMITable
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageMITable(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(MITable request)
        {
            await _context.MITables.AddAsync(request);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var mi = await _context.MITables.FindAsync(id);
            _context.Remove(mi);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(MITable request)
        {
            var mi = await _context.MITables.FindAsync(request.Id);
            mi.Name = request.Name;
            
            return await _context.SaveChangesAsync();
        }

        public async Task<List<MITable>> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            var mis = await _context.MITables.Where(x => x.Name.Contains(keyword)).ToListAsync();
            return mis;
        }

        public async Task<MITable> GetMITableById(int id)
        {
            return await _context.MITables.FindAsync(id);
        }
    }
}
