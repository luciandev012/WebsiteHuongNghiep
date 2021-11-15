using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Common;
using WebsiteHuongNghiep.Application.Request;
using WebsiteHuongNghiep.Application.ViewModels;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.BlogService
{
    public interface IManageBlogServices
    {
        Task<List<BlogVM>> GetAllBlog();
        Task<int> Create(BlogRequest request, Guid userId);
        Task<Blog> GetBlogByMetaTitle(string metaTitle);
        Task<int> Edit(int id, BlogRequest request, Guid userId);
        Task<BlogVM> GetBlogVMById(int id);
        Task<Blog> GetBlogById(int id);
        Task<PagedResult<BlogVM>> GetBlogPaging(string keyword, int pageIndex);
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task IncreaseViewCount(int id);
        Task<bool> UpdateImage(IFormFile image, int id);
        Task<int> Delete(int id);
    }
}
