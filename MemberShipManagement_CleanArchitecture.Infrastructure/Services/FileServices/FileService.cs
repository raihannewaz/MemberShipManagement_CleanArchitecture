﻿using MemberShipManagement_CleanArchitecture.Application.Services;
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

        public async Task<string> UploadImage(IFormFile file, string memberName, string phone)
        {
            string imagePath = "MemberFiles/" + memberName + "_" + phone + "/";
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = DateTime.Now.Ticks.ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var imgUrl = imagePath + uniqueFileName;

            return imgUrl;
        }

        public void UpdateFile(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                string existingPhotoPath = _webHostEnvironment.WebRootPath + "/" + url;
                if (File.Exists(existingPhotoPath))
                {
                    File.Delete(existingPhotoPath);
                }
            }
        }

    }
}
