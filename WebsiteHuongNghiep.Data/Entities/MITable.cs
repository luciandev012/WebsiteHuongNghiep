using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class MITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MIQuestion> MIQuestions { get; set; }
    }
}
