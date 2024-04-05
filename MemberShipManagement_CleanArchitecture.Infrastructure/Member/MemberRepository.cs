using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Member
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IWebHostEnvironment _webhost;
        private readonly DapperDbContext _dapperDbContext;
        private readonly ApplicationDbContext _context;
        public MemberRepository(IWebHostEnvironment webHost, DapperDbContext dapperDb, ApplicationDbContext dbContext)
        {
            _webhost = webHost;
            _dapperDbContext = dapperDb;
            _context = dbContext;
        }


        public async Task<Domain.MemberEntity.Member> CreateAsync(Domain.MemberEntity.Member member)
        {
            if (member.ImageFile != null)
            {
                if (!IsImageFileValid(member.ImageFile.FileName))
                {
                    throw new ArgumentException("Invalid image file format. Please upload a JPG or PNG file.");
                } 

                member.ProfileImageUrl = await UploadImageAsync(member.ImageFile);

            }
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public Task DeleteAsync(Domain.MemberEntity.Member member)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.MemberEntity.Member> UpdateAsync(Domain.MemberEntity.Member member)
        {
            throw new NotImplementedException();
        }


        public async Task<string> UploadImageAsync(IFormFile file)
        {
            string uploadsFolder = Path.Combine(_webhost.WebRootPath, "MemberImage\\");
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
