using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class MITracker
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public string TimeStamp { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
