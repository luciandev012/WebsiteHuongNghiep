using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services
{
    public interface IManageHLScoreServices
    {
        Task<int> Create(HollandScore request);
        Task<int> Update(HollandScore request);
        Task<int> Delete(int id);
    }
}
