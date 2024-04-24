using MediatR;
using MemberShipManagement_CleanArchitecture.Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Members.Query.GetById
{
    public class GetMemberByIdCommand : IRequest<IEnumerable<MemberDTO>>
    {
        public int MemberId { get; set; }
    }
}
