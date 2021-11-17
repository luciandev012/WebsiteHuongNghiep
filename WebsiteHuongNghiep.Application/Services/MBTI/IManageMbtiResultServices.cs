using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.MBTI
{
    public interface IManageMbtiResultServices
    {
        Task<int> Create(MbtiResult request);
        Task<int> Edit(MbtiResult request);
        Task<int> Delete(int id);
        Task<List<MbtiResult>> GetAll(string keyword);
        Task<MbtiResult> GetMbtiResultById(int id);
    }
}
