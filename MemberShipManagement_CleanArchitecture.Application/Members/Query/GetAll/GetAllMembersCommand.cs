using MemberShipManagement_CleanArchitecture.Application.Helpers;

namespace MemberShipManagement_CleanArchitecture.Application.Members.Query.GetAll
{
    public record GetAllMembersCommand(string? searchTerm) : IRequest<Pagination<MemberDTO>>
    {
        public int page = 1;
        public int pageSize = 3;
    }
}
