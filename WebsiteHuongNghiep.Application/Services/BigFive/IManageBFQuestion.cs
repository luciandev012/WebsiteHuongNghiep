using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.BigFive
{
    public interface IManageBFQuestion
    {
        Task<int> Create(BigFiveQuestion request);
        Task<int> Edit(BigFiveQuestion request);
        Task<int> Delete(int id);
        Task<List<BigFiveQuestion>> GetAll(string keyword);
        Task<BigFiveQuestion> GetBigFiveQuestionById(int id);

    }
}
