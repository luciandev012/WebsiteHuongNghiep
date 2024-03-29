﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public List<HollandTracker> HollandTrackers { get; set; }
        public List<MbtiTracker> MbtiTrackers { get; set; }
        public List<BigFiveTracker> BigFiveTrackers { get; set; }
        public List<EnnegramTracker> EnnegramTrackers { get; set; }
        public List<MITracker> MITrackers { get; set; }
    }
}
