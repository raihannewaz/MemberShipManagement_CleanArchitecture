using MemberShipManagement_CleanArchitecture.Application.Helpers;

namespace MemberShipManagement_CleanArchitecture.Application.Members.Query.GetAll
{
    public record GetAllMembersCommand(string? searchTerm, int page, int pageSize) : IRequest<Pagination<MemberDTO>>
    {

    }
}
