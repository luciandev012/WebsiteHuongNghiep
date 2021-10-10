using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class HollandTracker
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        //
        //Summary:
        //      To save current step of test making progress of user.
        public int Step { get; set; } 
        public int Times { get; set; } // to indicate times of making test of user
        public string TimeStamp { get; set; } // to link with Holland Score table
        public User User { get; set; }
    }
}
