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

        public async Task<List<Blog>> GetAllBlog()
        {
            var blogs = await _context.Blogs.ToListAsync();
            return blogs;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Common.Common.ConvertToUnSign(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
