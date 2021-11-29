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
    public class ManageMIQuestion : IManageMIQuestion
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageMIQuestion(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(MIQuestion request)
        {
            await _context.MIQuestions.AddAsync(request);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var mi = await _context.MIQuestions.FindAsync(id);
            _context.MIQuestions.Remove(mi);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(MIQuestion request)
        {
            var mi = await _context.MIQuestions.FindAsync(request.Id);
            mi.Question = request.Question;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<MIQuestion>> GetAll(string keyword)
        {
            if(string.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            return await _context.MIQuestions.Where(x => x.Question.Contains(keyword)).ToListAsync();
        }

        public async Task<MIQuestion> GetById(int id)
        {
            return await _context.MIQuestions.FindAsync(id);
        }
        public async Task<int> Execute(int[] score, int[] tableId)
        {
            int[] result = new int[8];
            for(int i = 0; i < score.Length; i++)
            {
                result[tableId[i] - 1] += score[i];
            }
            int res = GetMaxIndex(result) + 1;
            return res;

        }
        private int GetMaxIndex(int[] arr)
        {
            int max = int.MinValue;
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    index = i;
                }

            }
            return index;
        }
    }
}
