using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.MI
{
    public interface IManageMITracker
    {
        Task<int> Create(MITracker tracker);
        Task<int> CountTracker();
        Task<List<MITracker>> GetTrackerByUserId(Guid userId);
        Task<int> CountTrackerByResult(int resultId);
        Task<int> CountUser();
        Task<List<TrackerVM>> GetAll();
    }
}
