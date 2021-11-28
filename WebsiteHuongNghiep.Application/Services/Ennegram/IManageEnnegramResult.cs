using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.Ennegram
{
    public interface IManageEnnegramResult
    {
        Task<int> Create(EnnegramResult request);
        Task<int> Edit(EnnegramResult request);
        Task<int> Delete(int id);
        Task<List<EnnegramResult>> GetAll(string keyword);
        Task<EnnegramResult> GetEnnegramResultById(int id);
        Task<EnnegramResult> GetEnnegramResultByResultCode(string resultCode);
    }
}
