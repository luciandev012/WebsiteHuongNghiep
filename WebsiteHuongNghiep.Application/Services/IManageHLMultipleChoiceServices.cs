using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services
{
    public interface IManageHLMultipleChoiceServices
    {
        Task<int> Create(HollandMultipleChoice request);
        Task<int> Update(HollandMultipleChoice request);
        Task<int> Delete(int id);
    }
}
