using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.Ennegram
{
    public interface IManageEGTracker
    {
        Task<int> Create(EnnegramTracker tracker);
        Task<int> CountTracker();
        Task<List<EnnegramTracker>> GetTrackerByUserId(Guid userId);
        Task<int> CountTrackerByResult(string resultCode);
        Task<int> CountUser();
        Task<List<TrackerVM>> GetAll();
    }
}
