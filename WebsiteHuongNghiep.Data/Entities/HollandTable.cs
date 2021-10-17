using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class HollandTable
    {
        public int HLTableId { get; set; }
        [Display( Name = "Tên bảng")]
        public string Name { get; set; }

        public List<HollandMultipleChoice> HollandMutipleChoices { get; set; }
    }
}
