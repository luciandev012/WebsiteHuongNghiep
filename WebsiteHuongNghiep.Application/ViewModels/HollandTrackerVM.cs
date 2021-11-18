using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Application.ViewModels
{
    public class TrackerVM
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string TimeStamp { get; set; }
        public int SameResultCount { get; set; }
        public float SameResultPercent { get; set; }
        public string FinalResult { get; set; }
    }
}
