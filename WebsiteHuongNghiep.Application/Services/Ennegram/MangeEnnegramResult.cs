using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.Ennegram
{
    public class MangeEnnegramResult : IManageEnnegramResult
    {
        private readonly VocationalGuidanceDbContext _context;
        public MangeEnnegramResult(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(EnnegramResult request)
        {
            await _context.AddAsync(request);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var eg = await _context.EnnegramResults.FindAsync(id);
            _context.Remove(eg);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(EnnegramResult request)
        {
            var eg = await _context.EnnegramResults.FindAsync(request.Id);
            eg.Content = request.Content;
            eg.Name = request.Name;
            eg.ResultCode = request.ResultCode;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<EnnegramResult>> GetAll(string keyword)
        {
            if(string.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            return await _context.EnnegramResults.Where(x => x.Name.Contains(keyword) || x.Content.Contains(keyword)).ToListAsync();
        }

        public async Task<EnnegramResult> GetEnnegramResultById(int id)
        {
            return await _context.EnnegramResults.FindAsync(id);
        }

        public async Task<EnnegramResult> GetEnnegramResultByResultCode(string resultCode)
        {
            return await _context.EnnegramResults.Where(x => x.ResultCode == resultCode).FirstOrDefaultAsync();
        }
    }
}
