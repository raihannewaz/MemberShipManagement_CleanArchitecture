using MemberShipManagement_CleanArchitecture.Application.DTO_s;
using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;

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
        private readonly DapperDbContext _dapperDbContext;
        private readonly ApplicationDbContext _context;
        public MemberRepository(DapperDbContext dapperDb, ApplicationDbContext dbContext)
        {
            _dapperDbContext = dapperDb;
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

        public async Task<IEnumerable<Domain.MemberEntity.Member>> GetByIdSql(string a)
        {
            using (var conn = _dapperDbContext.CreateConnection())
            {
                var data = await conn.QueryMultipleAsync(a);

                var member = await data.ReadSingleAsync<Domain.MemberEntity.Member>();
                var doc = await data.ReadAsync<DocumentDTO>();
                var address = await data.ReadAsync<AddressDTO>();
                var membership = await data.ReadAsync<MembershipDTO>();

                //member.Document = doc.ToList();
                //member.Address = address.ToList();
                //member.Membership = membership.ToList();

                return new List<Domain.MemberEntity.Member> { member };
            }
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
