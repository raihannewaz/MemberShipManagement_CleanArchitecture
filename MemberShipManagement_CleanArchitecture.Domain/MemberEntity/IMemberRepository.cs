
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MemberShipManagement_CleanArchitecture.Domain.MemberEntity
{
    public interface IMemberRepository
    {
        Task CreateAsync(Member member);
        Task UpdateAsync(Member member);
        Task DeleteAsync(Member member);
        //Task<IReadOnlyList<MemberDTO>> GetByIdSql(string a);
        Task<Member> GetById(int a);

        //Task<IReadOnlyList<MemberDTO>> GetAllAsync(string a);
        Task SaveChangeAsync();
    }
}
