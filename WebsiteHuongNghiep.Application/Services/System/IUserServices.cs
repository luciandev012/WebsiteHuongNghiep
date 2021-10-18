using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Request;

namespace WebsiteHuongNghiep.Application.Services.System
{
    public interface IUserServices
    {
        Task<Response> Authenticate(LoginRequest request);
        Task<Response> Register(RegisterRequest request);
    }
}
