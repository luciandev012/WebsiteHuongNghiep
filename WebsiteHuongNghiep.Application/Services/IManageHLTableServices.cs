using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services
{
    public interface IManageHLTableServices
    {
        Task<int> Create(HollandTable request);
        Task<int> Update(HollandTable request);
        Task<int> Delete(int id);
        Task<List<HollandTable>> GetAll();
        Task<HollandTable> GetById(int id);
    }
}
