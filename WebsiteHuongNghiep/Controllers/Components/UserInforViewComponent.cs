using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Controllers.Components
{
    public class UserInforViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            User user = new User();
            user.FirstName = HttpContext.Session.GetString("UserName");
            return View("Default", user);
        }
    }
}
