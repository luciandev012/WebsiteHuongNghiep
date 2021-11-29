using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class MIQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int TableId { get; set; }
        public MITable MITable { get; set; }

    }
}
