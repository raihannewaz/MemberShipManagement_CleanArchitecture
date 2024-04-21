using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using Microsoft.EntityFrameworkCore;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Document
{
    internal class DocumentRepository : IDocumentRepository
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext dbContext, IWebHostEnvironment webHost)
        {
            _context = dbContext;
            _webHost = webHost;
        }


        public async Task<Domain.DocumentEntity.Document> CreateAync(Domain.DocumentEntity.Document a)
        {
            if (a.FileType != null)
            {
                if (!IsImageFileValid(a.FileType.FileName))
                {
                    throw new ArgumentException("Invalid image file format. Please upload a JPG or PNG file.");
                }
                string url = await UploadImageAsync(a.FileType);
                a.FileUrl(url);


            }
            await _context.Documents.AddAsync(a);
            return a;
        }


        public async Task<Domain.DocumentEntity.Document> GetById(int id, string type)
        {
            return await _context.Documents.FirstOrDefaultAsync(d=>d.MemberId ==  id && d.DocumentType == type);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.DocumentEntity.Document a)
        {
            if (a.FileType != null)
            {
                if (!string.IsNullOrEmpty(a.DocumentUrl))
                {
                    string existingPhotoPath = a.DocumentUrl;
                    if (File.Exists(existingPhotoPath))
                    {
                        File.Delete(existingPhotoPath);
                    }
                }
                var url = await UploadImageAsync(a.FileType);
                a.FileUrl(url);

            }
            _context.Entry(a).State = EntityState.Modified;
        }


        public async Task<string> UploadImageAsync(IFormFile file)
        {
            string uploadsFolder = Path.Combine(_webHost.WebRootPath, "DocumentsFile\\");
            string uniqueFileName = DateTime.Now.Ticks.ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var imgUrl = uploadsFolder + uniqueFileName;

            return imgUrl;
        }

        private bool IsImageFileValid(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png";
        }
    }
}
