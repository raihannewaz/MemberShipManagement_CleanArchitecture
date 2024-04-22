using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

                string url = await UploadImageAsync(member.ImageFile);
                member.PhotoUrl(url);


            }
            member.AccountCreateDate = DateTime.Now;
            member.IsActive = true;
            await _context.Members.AddAsync(member);

            return member;
        }

        public Task DeleteAsync(Domain.MemberEntity.Member member)
        {
             _context.Members.Remove(member);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyList<Domain.MemberEntity.Member>> GetAllAsync(string a)
        {
            using (var conn =  _dapperDbContext.CreateConnection())
            {
                var result = await conn.QueryMultipleAsync(a);

                var members = await result.ReadAsync<Domain.MemberEntity.Member>();
                
                return members.ToList();
            }
        }

        public async Task<Domain.MemberEntity.Member> GetById(int a)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.MemberId == a);
        }

        public async Task<IEnumerable<Domain.MemberEntity.Member>> GetByIdSql(string a)
        {
            using (var conn = _dapperDbContext.CreateConnection())
            {
                var data = await conn.QueryMultipleAsync(a);

                var member = await data.ReadSingleAsync<Domain.MemberEntity.Member>();
                var doc = await data.ReadAsync<Domain.DocumentEntity.Document>();
                var address = await data.ReadAsync<Domain.AddressEntity.Address>();
                var membership = await data.ReadAsync<Domain.MembershipEntity.Membership>();

                member.Document = doc.ToList();
                member.Address = address.ToList();
                member.Membership = membership.ToList();
                
                return new List<Domain.MemberEntity.Member> { member};
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
                var url = await UploadImageAsync(member.ImageFile);
                member.PhotoUrl(url);

            }
            _context.Entry(member).State = EntityState.Modified;
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
