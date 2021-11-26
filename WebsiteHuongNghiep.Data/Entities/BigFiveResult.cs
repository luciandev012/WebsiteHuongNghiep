using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.Entities
{
    public class BigFiveResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public List<BigFiveQuestion> BigFiveQuestions { get; set; }
    }
}
