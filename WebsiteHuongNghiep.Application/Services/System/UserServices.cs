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
        public async Task<Response<User>> Authenticate(LoginRequest request)
        {
            //var user = await _userManager.FindByNameAsync(request.PhoneNumber);
            var user = await _context.Users.Where(x => x.UserName == request.PhoneNumber).FirstOrDefaultAsync();
            if(user == null)
            {
                return new Response<User>(false, "User is not exsist", null);
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            var role = await _signInManager.UserManager.GetRolesAsync(user);
            if (!result.Succeeded)
            {
                return new Response<User>(success: false, message: "Password is not correct!", null);
            }
            return new Response<User>(true, role[0], user);

        }

        public async Task<Response<User>> Register(RegisterRequest request)
        {
            var user = new User()
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                UserName = request.PhoneNumber,
                PhoneNumber = request.PhoneNumber,
                LockoutEnabled = false
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new Response<User>(true, "Đăng ký thành công!", null);
            }
            return new Response<User>(false, result.Errors.First().Description, null);
        }
    }
}
