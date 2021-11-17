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
        public async Task<string> GetResult(int[] score)
        {
            string result = "";
            int e, i, s, n, t, f, j, p; e = i = s = n = t = f = j = p = 0;
            var loop = score.Length / 14;
            for(int index = 0; index < loop; index++)
            {
                index *= 14;
                e += score[index + 0];
                i += score[index + 1];
                s += score[index + 2] + score[index + 4];
                n += score[index + 3] + score[index + 5];
                t += score[index + 6] + score[index + 8];
                f += score[index + 7] + score[index + 9];
                j += score[index + 10] + score[index + 12];
                p += score[index + 11] + score[index + 13];
            }
            if(e > i)
            {
                result += "E";
            }
            else
            {
                result += "I";
            }
            if (s > n)
            {
                result += "S";
            }
            else
            {
                result += "N";
            }
            if (t > f)
            {
                result += "T";
            }
            else
            {
                result += "F";
            }
            if (j > p)
            {
                result += "J";
            }
            else
            {
                result += "P";
            }
            return result;
        }

        public async Task<MbtiResult> GetMbtiResult(string finalResult)
        {
            var mbtiResult = await _context.MbtiResults.Where(x => x.FinalResult == finalResult).FirstOrDefaultAsync();
            return mbtiResult;
        }
    }
}
