using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.BigFive
{
    public interface IManageBFTracker
    {
        Task<int> Create(BigFiveTracker tracker);
        Task<int> CountTracker();
        Task<List<BigFiveTracker>> GetTrackerByUserId(Guid userId);
        Task<int> CountTrackerByResult(int result);
        Task<int> CountUser();
        Task<List<TrackerVM>> GetAll();
    }
}
