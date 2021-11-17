using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.MBTI
{
    public interface IManageMbtiTableServices
    {
        Task<List<MbtiTable>> GetMbtiTables();
        Task<int> Create(MbtiTable request);
        Task<int> Edit(MbtiTable request);
        Task<int> Delete(int id);
        Task<MbtiTable> GetMbtiTableById(int id);
    }
}
