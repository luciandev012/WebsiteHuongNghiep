using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Application.ViewModels
{
    public class BlogVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public int ViewCount { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string Category { get; set; }
        
    }
}
