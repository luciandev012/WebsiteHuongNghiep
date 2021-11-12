using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebsiteHuongNghiep.Application.Common
{
    public class StorageService : IStorageService
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public StorageService(IHostEnvironment webHostEnviroment)
        {
            var path = Path.Combine(webHostEnviroment.ContentRootPath, "wwwroot");
            _userContentFolder = Path.Combine(path, USER_CONTENT_FOLDER_NAME);
        }
        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{_userContentFolder}/{fileName}";
        }

        public async Task SaveFileAsync(Stream meadiaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await meadiaBinaryStream.CopyToAsync(output);
        }
        public string GetPath(string filename)
        {
            return Path.Combine(_userContentFolder, filename);
        }
        public string GetFolder()
        {
            return _userContentFolder;
        }
    }
}
