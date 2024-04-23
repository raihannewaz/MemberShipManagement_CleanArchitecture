using MediatR;
using MemberShipManagement_CleanArchitecture.Application.DTO_s;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MemberShipManagement_CleanArchitecture.Application.Members.Query
{
    public class MemberQueries : IRequest<IEnumerable<MemberDTO>>
    {
        public int MemberId;

        public string Query;

        public string MemberDetails(int id)
        {
            return @$"SELECT * FROM Members where MemberId = {id}
                      SELECT * From Documents where MemberId = {id}
                      SELECT * From Addresses where MemberId = {id};
                      SELECT * From Memberships where MemberId = {id}";
        }

        public string AllMembers = "SELECT* From Members";
    }

}
