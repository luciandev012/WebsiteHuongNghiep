using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Common;
using WebsiteHuongNghiep.Application.Request;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.BlogService
{
    public class ManageBlogService : IManageBlogServices
    {
        private readonly VocationalGuidanceDbContext _context;
        private readonly IStorageService _storageService;
        public ManageBlogService(VocationalGuidanceDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(BlogRequest request, Guid userId)
        {
            var blog = new Blog()
            {
                Name = request.Name,
                Title = request.Title,
                MetaTitle = Common.Common.ConvertToUnSign(request.Title),
                CategoryId = request.CategoryId,
                Content = request.Content,
                CreatedAt = DateTime.Now,
                CreatedBy = userId,
                ViewCount = 0,
                Image = await SaveFile(request.Image)
            };
            await _context.AddAsync(blog);
            return await _context.SaveChangesAsync();
        }
        public async Task<Blog> GetBlogByMetaTitle(string metaTitle)
        {
            var blog = await _context.Blogs.Where(x => x.MetaTitle == metaTitle).FirstOrDefaultAsync();
            return blog;
        }

        public async Task<List<BlogVM>> GetAllBlog()
        {
            var blogs = await _context.Blogs.ToListAsync();
            var blogVMs = new List<BlogVM>();
            foreach(var item in blogs)
            {
                var blogVm = new BlogVM()
                {
                    Category = (await _context.Categories.FindAsync(item.CategoryId)).Name,
                    Name = item.Name,
                    Content = item.Content,
                    CreatedAt = item.CreatedAt,
                    Id = item.Id,
                    Image = item.Image,
                    ModifyDate = item.ModifyDate,
                    Title = item.Title,
                    MetaTitle = item.MetaTitle,
                    ViewCount = item.ViewCount,
                    ModifyBy = (await _context.Users.FindAsync(item.ModifyBy)) == null? "" : (await _context.Users.FindAsync(item.ModifyBy)).FirstName,
                    CreatedBy = (await _context.Users.FindAsync(item.CreatedBy)).FirstName
                    
                };
                blogVMs.Add(blogVm);
            }
            return blogVMs;
        }

        public async Task<int> Edit(int id, BlogRequest request, Guid userId)
        {
            var blog = await _context.Blogs.FindAsync(id);
            blog.Name = request.Name;
            blog.Title = request.Title;
            blog.MetaTitle = Common.Common.ConvertToUnSign(request.Title);
            blog.Content = request.Content;
            blog.ModifyDate = DateTime.Now;
            blog.ModifyBy = userId;
            blog.CategoryId = request.CategoryId;
            //blog.Image = await SaveFile(request.Image);
            return await _context.SaveChangesAsync();
        }

        public async Task<BlogVM> GetBlogVMById(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            var blogVm = new BlogVM()
            {
                Category = (await _context.Categories.FindAsync(blog.CategoryId)).Name,
                Name = blog.Name,
                Content = blog.Content,
                CreatedAt = blog.CreatedAt,
                Id = blog.Id,
                Image = blog.Image,
                ModifyDate = blog.ModifyDate,
                Title = blog.Title,
                MetaTitle = blog.MetaTitle,
                ViewCount = blog.ViewCount,
                ModifyBy = (await _context.Users.FindAsync(blog.ModifyBy)) == null ? "" : (await _context.Users.FindAsync(blog.ModifyBy)).FirstName,
                CreatedBy = (await _context.Users.FindAsync(blog.CreatedBy)).FirstName

            };
            return blogVm;
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task<PagedResult<BlogVM>> GetBlogPaging(string keyword, int pageIndex)
        {
            if (String.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            var blogs = await _context.Blogs.Where(x => x.Name.Contains(keyword)).ToListAsync();
            int totalRow = blogs.Count;
            blogs = blogs.Skip((pageIndex - 1) * 6).Take(6).ToList();

            var blogVMs = new List<BlogVM>();
            foreach (var item in blogs)
            {
                var blogVm = new BlogVM()
                {
                    Category = (await _context.Categories.FindAsync(item.CategoryId)).Name,
                    Name = item.Name,
                    Content = item.Content,
                    CreatedAt = item.CreatedAt,
                    Id = item.Id,
                    Image = item.Image,
                    ModifyDate = item.ModifyDate,
                    Title = item.Title,
                    MetaTitle = item.MetaTitle,
                    ViewCount = item.ViewCount,
                    ModifyBy = (await _context.Users.FindAsync(item.ModifyBy)) == null ? "" : (await _context.Users.FindAsync(item.ModifyBy)).FirstName,
                    CreatedBy = (await _context.Users.FindAsync(item.CreatedBy)).FirstName

                };
                blogVMs.Add(blogVm);
            }

            var pagedResult = new PagedResult<BlogVM>()
            {
                Items = blogVMs,
                PageIndex = pageIndex,
                PageSize = 2,
                TotalRecord = totalRow
            };
            return pagedResult;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Common.Common.ConvertToUnSign(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task IncreaseViewCount(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            blog.ViewCount++;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateImage(IFormFile image, int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            blog.Image = await SaveFile(image);
            return await _context.SaveChangesAsync() == 1;

        }
        public async Task<int> Delete(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            _context.Remove(blog);
            return await _context.SaveChangesAsync();
        }
    }
}
