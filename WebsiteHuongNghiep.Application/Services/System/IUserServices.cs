using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Request;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.System
{
    public interface IUserServices
    {
        Task<Response<User>> Authenticate(LoginRequest request);
        Task<Response<User>> Register(RegisterRequest request);
        Task<List<User>> GetUser(string phoneNumber);
        Task<User> GetUserById(Guid userId);
        Task<bool> Edit(Guid userId, User userRequest);
        Task<int> Delete(Guid userId);
        Task<bool> ForgotPassword(RegisterRequest request);
        Task<User> GetUserById(string id);
    }
}
