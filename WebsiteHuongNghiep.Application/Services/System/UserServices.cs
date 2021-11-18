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

        public async Task<int> Delete(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var userRole = await _context.UserRoles.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            _context.UserRoles.Remove(userRole);
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();

        }

        public async Task<bool> Edit(Guid userId, User userRequest)
        {
            //var userResult = await _userManager.UpdateAsync(userRequest);
            var user = await _context.Users.FindAsync(userId);
            user.FirstName = userRequest.FirstName;
            user.LastName = userRequest.LastName;
            user.UserName = userRequest.UserName;
            user.DoB = userRequest.DoB;
            user.Email = userRequest.Email;
            user.PhoneNumber = userRequest.PhoneNumber;
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<User>> GetUser(string phoneNumber)
        {
            if (String.IsNullOrEmpty(phoneNumber))
            {
                phoneNumber = "";
            }
            var users = await _userManager.Users.Where(x => x.UserName.Contains(phoneNumber)).ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<Response<User>> Register(RegisterRequest request)
        {
            var existUser = await _userManager.FindByNameAsync(request.PhoneNumber);
            if(existUser != null)
            {
                return new Response<User>(false, "Đăng kí thất bại, trùng số điện thoại!", null);
            }
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
                var role = await _context.Roles.Where(x => x.Name == "student").FirstOrDefaultAsync();
                var realUser = await _context.Users.Where(x => x.UserName == request.PhoneNumber).FirstOrDefaultAsync();
                await _userManager.AddToRoleAsync(user, "student");

                return new Response<User>(true, "Đăng ký thành công!", null);
            }
            return new Response<User>(false, result.Errors.First().Description, null);
        }
        public async Task<bool> ForgotPassword(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.PhoneNumber);
            if(user == null)
            {
                return false;
            }
            if(user.FirstName != request.FirstName || user.LastName != request.LastName)
            {
                return false;
            }
            var password = _userManager.PasswordHasher.HashPassword(user, request.Password);
            user.PasswordHash = password;
            
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<User> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;

        }
    }
}
