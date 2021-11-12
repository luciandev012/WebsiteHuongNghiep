using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Application.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);
        Task SaveFileAsync(Stream meadiaBinaryStream, string fileName);
        Task DeleteFileAsync(string fileName);
        string GetFolder();
        string GetPath(string filename);
    }
}
