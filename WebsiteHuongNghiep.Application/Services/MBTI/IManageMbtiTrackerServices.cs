using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.MBTI
{
    public interface IManageMbtiTrackerServices
    {
        Task Create(string finalResult, string timeStamp, Guid userId);
        Task<int> CountTracker();
        Task<List<MbtiTracker>> GetTrackerByUserId(Guid userId);
        Task<int> CountTrackerByFinalResult(string finalResult);
    }
}
