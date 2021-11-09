using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Application.ViewModels
{
    public class HollandTrackerVM
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string TimeStamp { get; set; }
        public int SameResultCount { get; set; }
        public float SameResultPercent { get; set; }
    }
}
