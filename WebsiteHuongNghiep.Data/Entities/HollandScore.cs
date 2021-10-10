using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class HollandScore
    {
        public int Id { get; set; }
        public int Table { get; set; }
        public int Score { get; set; }
        public string TimeStamp { get; set; }
    }
}
