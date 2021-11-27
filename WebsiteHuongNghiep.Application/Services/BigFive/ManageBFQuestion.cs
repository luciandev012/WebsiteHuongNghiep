using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.BigFive
{
    public class ManageBFQuestion : IManageBFQuestion
    {
        private readonly VocationalGuidanceDbContext _context;
        public ManageBFQuestion(VocationalGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(BigFiveQuestion request)
        {
            await _context.BigFiveQuestions.AddAsync(request);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var b5 = await _context.BigFiveQuestions.FindAsync(id);
            _context.Remove(b5);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(BigFiveQuestion request)
        {
            var b5 = await _context.BigFiveQuestions.FindAsync(request.Id);
            b5.Question = request.Question;
            b5.BigFiveResultId = request.BigFiveResultId;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<BigFiveQuestion>> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            var b5s = await _context.BigFiveQuestions.Where(x => x.Question.Contains(keyword)).ToListAsync();
            return b5s;
        }

        public async Task<BigFiveQuestion> GetBigFiveQuestionById(int id)
        {
            return await _context.BigFiveQuestions.FindAsync(id);
        }
        public async Task<List<BigFiveVM>> GetBigFiveVMs()
        {
            var b5vms = new List<BigFiveVM>();
            var b5s = await GetAll("");
            b5s = b5s.OrderBy(i => Guid.NewGuid()).ToList();
            int index = 1;
            foreach(var item in b5s)
            {
                var b5vm = new BigFiveVM()
                {
                    Index = index,
                    Question = item.Question,
                    ResultId = item.BigFiveResultId,
                    Score = 0
                };
                b5vms.Add(b5vm);
                index++;
            }    

            return b5vms;
        }
        public async Task<int> GetResult(int[] score, int[] resultId)
        {
            var result = new int[5];
            for(int i = 0; i < score.Length; i++)
            {
                result[resultId[i] - 1] += score[i];
            }
            return GetMaxIndex(result) + 1;

        }
        private int GetMaxIndex(int[] arr)
        {
            int max = int.MinValue;
            int index = 0;
            for(int i = 0; i < arr.Length; i++)
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
