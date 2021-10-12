using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services
{
    public interface IManageHLResultServices
    {
        Task<int> Create(HollandResult request);
        Task<int> Update(HollandResult request);
        Task<int> Delete(int id);
    }
}
