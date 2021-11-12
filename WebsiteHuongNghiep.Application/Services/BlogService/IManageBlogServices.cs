using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Request;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.BlogService
{
    public interface IManageBlogServices
    {
        Task<List<Blog>> GetAllBlog();
        Task<int> Create(BlogRequest request, Guid userId);
        Task<Blog> GetBlogByMetaTitle(string metaTitle);
    }
}
