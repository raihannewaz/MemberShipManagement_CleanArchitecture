using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
            member.AccountCreateDate = DateTime.Now;
            member.IsActive = true;
            await _context.Members.AddAsync(member);

            return member;
        }

        public async Task DeleteAsync(Domain.MemberEntity.Member member)
        {
             _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.MemberEntity.Member> GetById(int id)
        {
            using (var conn = _dapperDbContext.CreateConnection())
            {
                var sq = $"SELECT * FROM Members WHERE MemberId = {id}";

                var data = await conn.QueryFirstOrDefaultAsync<Domain.MemberEntity.Member>(sq);

                return data;
            }
        }


        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.MemberEntity.Member member)
        {
            if (member.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(member.ProfileImageUrl))
                {
                    string existingPhotoPath = member.ProfileImageUrl;
                    if (File.Exists(existingPhotoPath))
                    {
                        File.Delete(existingPhotoPath);
                    }
                }

                member.ProfileImageUrl = await UploadImageAsync(member.ImageFile);

            }
            _context.Entry(member).State = EntityState.Modified;
            await _context.SaveChangesAsync();
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
