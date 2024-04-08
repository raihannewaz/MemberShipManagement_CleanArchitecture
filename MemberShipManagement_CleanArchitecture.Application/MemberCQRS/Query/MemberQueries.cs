using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Query
{
    public class MemberQueries: IRequest<IEnumerable<Member>>
    {
        public int MemberId { get; set; }

        //public string MemberByIdSql()
        //{
        //    return $"SELECT * FROM Members Where MemberId={MemberId}";
        //}
    }

}
