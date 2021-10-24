using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Request;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.System
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly VocationalGuidanceDbContext _context;
        //private readonly RoleManager<Role> _roleManager;
        public UserServices(UserManager<User> userManager, SignInManager<User> signInManager, VocationalGuidanceDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _context = context;
        }
        public async Task<Response> Authenticate(LoginRequest request)
        {
            //var user = await _userManager.FindByNameAsync(request.PhoneNumber);
            var user = await _context.Users.Where(x => x.UserName == request.PhoneNumber).FirstOrDefaultAsync();
            if(user == null)
            {
                return new Response()
                {
                    Success = false,
                    Message = "User is not exist!"
                };
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new Response()
                {
                    Success = false,
                    Message = "Password is not correct!"
                };
            }
            return new Response()
            {
                Success = true,
                Message = "Login successfully!"
            };

        }

        public async Task<Response> Register(RegisterRequest request)
        {
            var user = new User()
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                UserName = request.PhoneNumber,
                PhoneNumber = request.PhoneNumber,

            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new Response()
                {
                    Success = true,
                    Message = "Đăng ký thành công!"
                };
            }
            return new Response()
            {
                Success = false,
                Message = "Đăng ký không thành công!"
            };
        }
    }
}
