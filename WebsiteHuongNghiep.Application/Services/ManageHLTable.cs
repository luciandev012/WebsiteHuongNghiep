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
    public class ManageHLTable : IManageHLTableServices
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageHLTable(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(HollandTable request)
        {
            var hlTable = new HollandTable()
            {
                Name = request.Name
            };
            await _context.HollandTables.AddAsync(hlTable);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var hlTable = await _context.HollandTables.FindAsync(id);
            _context.HollandTables.Remove(hlTable);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<HollandTable>> GetAll()
        {
            var hlTables = await _context.HollandTables.ToListAsync();
            return hlTables;
        }

        public async Task<int> Update(HollandTable request)
        {
            var hlTable = await _context.HollandTables.FindAsync(request.HLTableId);
            hlTable.Name = request.Name;
            return await _context.SaveChangesAsync();
        }
        public async Task<HollandTable> GetById(int id)
        {
            return await _context.HollandTables.FindAsync(id);
        }

    }
}
