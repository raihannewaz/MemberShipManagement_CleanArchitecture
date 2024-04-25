using MemberShipManagement_CleanArchitecture.Application.DTO_s;
using MemberShipManagement_CleanArchitecture.Application.Services;
using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
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
        
        private readonly ApplicationDbContext _context;


        public MemberRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;

        }


        public async Task CreateAsync(Domain.MemberEntity.Member member)
        {
            await _context.Members.AddAsync(member);
        }


        public Task DeleteAsync(Domain.MemberEntity.Member member)
        {
             _context.Members.Remove(member);
            return Task.CompletedTask;
        }


        public async Task<Domain.MemberEntity.Member> GetById(int a)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.MemberId == a);
        }


        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.MemberEntity.Member member)
        {
         
            _context.Entry(member).State = EntityState.Modified;
        }

      


        //private bool IsImageFileValid(string fileName)
        //{
        //    string extension = Path.GetExtension(fileName).ToLower();
        //    return extension == ".jpg" || extension == ".jpeg" || extension == ".png";
        //}


    }
}
