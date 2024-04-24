using MemberShipManagement_CleanArchitecture.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Services.FileServices
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "MemberFiles\\");
            string uniqueFileName = DateTime.Now.Ticks.ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var imgUrl = "MemberFiles\\" + uniqueFileName;

            return imgUrl;
        }

        public void UpdateFile(string url)
        {

            if (!string.IsNullOrEmpty(url))
            {
                string existingPhotoPath = _webHostEnvironment.WebRootPath + "\\" + url;
                if (File.Exists(existingPhotoPath))
                {
                    File.Delete(existingPhotoPath);
                }

            }
        }

    }
}
