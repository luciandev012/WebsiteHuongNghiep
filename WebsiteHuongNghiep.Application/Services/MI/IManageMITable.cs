using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.MI
{
    public interface IManageMITable
    {
        Task<int> Create(MITable request);
        Task<int> Edit(MITable request);
        Task<int> Delete(int id);
        Task<List<MITable>> GetAll(string keyword);
        Task<MITable> GetMITableById(int id);
    }
}
