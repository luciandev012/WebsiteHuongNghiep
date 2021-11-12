using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public int ViewCount { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public Guid ModifyBy { get; set; }
        
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
