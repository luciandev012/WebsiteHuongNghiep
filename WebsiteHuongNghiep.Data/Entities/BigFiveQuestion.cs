using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class BigFiveQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int BigFiveResultId { get; set; }
        public BigFiveResult BigFiveResult { get; set; }
    }
}
