using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Application
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T ResponseObj { get; set; }
        public Response(bool success, string message, T obj)
        {
            ResponseObj = obj;
            Success = success;
            Message = message;
        }
    }
}
