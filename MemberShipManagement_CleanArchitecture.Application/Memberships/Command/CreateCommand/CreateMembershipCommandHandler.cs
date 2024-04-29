

namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Command.CreateCommand
{
    //internal sealed class CreateMembershipCommandHandler : IRequestHandler<CreateMembershipCommand, int>
    //{
    //    private readonly IMembershipRepository _membershipRepository;
    //    private readonly IPackageRepository _packageRepository;

    //    public CreateMembershipCommandHandler(IMembershipRepository membershipRepository, IPackageRepository packageRepository)
    //    {
    //        _membershipRepository = membershipRepository;
    //        _packageRepository = packageRepository;
    //    }

    //    public async Task<int> Handle(CreateMembershipCommand request, CancellationToken cancellationToken)
    //    {
            
    //        var pack = await _packageRepository.GetById(request.PackageId);
    //        var data = Membership.CreateMembership(request.MemberId, request.PackageId, request.Quantity);
    //        data.AssignPackage(pack);
    //        await _membershipRepository.CreateAsync(data);
    //        await _membershipRepository.SaveChangeAsync();

    //        return request.MemberId;
    //    }
    //}
}
