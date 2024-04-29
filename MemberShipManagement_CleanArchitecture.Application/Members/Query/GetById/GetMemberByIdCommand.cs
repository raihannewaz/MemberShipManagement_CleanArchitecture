

namespace MemberShipManagement_CleanArchitecture.Application.Members.Query.GetById
{
    public class GetMemberByIdCommand : IRequest<IEnumerable<MemberDTO>>
    {
        public int MemberId { get; set; }
    }
}
