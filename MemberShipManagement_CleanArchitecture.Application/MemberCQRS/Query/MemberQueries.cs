using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Query
{
    public class MemberQueries : IRequest<IEnumerable<Member>>
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
