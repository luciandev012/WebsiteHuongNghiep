using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class HollandMultipleChoice
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int HLTableId { get; set; }
        public HollandTable HollandTable { get; set; }
    }
}
