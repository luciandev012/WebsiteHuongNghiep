using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.BigFive
{
    public interface IManageBFResult
    {
        Task<int> Create(BigFiveResult request);
        Task<int> Edit(BigFiveResult request);
        Task<int> Delete(int id);
        Task<List<BigFiveResult>> GetAll(string keyword);
        Task<BigFiveResult> GetBigFiveResultById(int id);
    }
}
