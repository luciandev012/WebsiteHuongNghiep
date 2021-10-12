using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services
{
    public interface IManageHLTrackerServices
    {
        Task<int> Create(HollandTracker request);
        Task<int> Update(HollandTracker request);
        Task<int> Delete(int id);
    }
}
