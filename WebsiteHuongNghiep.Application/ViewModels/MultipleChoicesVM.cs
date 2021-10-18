using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Application.ViewModels
{
    public class MultipleChoicesVM
    {
        public int Id { get; set; }
        [Display(Name = "Câu hỏi")]
        public string Question { get; set; }
        [Display(Name = "Bảng")]
        public string Table { get; set; }
    }
}
