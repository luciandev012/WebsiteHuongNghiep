﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Application.Request
{
    public class LoginRequest
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
