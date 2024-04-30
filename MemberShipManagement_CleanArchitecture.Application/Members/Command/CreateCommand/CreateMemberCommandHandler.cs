

namespace MemberShipManagement_CleanArchitecture.Application.Members.Command.CreateCommand
{
    internal sealed class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, int>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IFileService _fileService;
        private readonly IPackageRepository _packageRepository;


        public CreateMemberCommandHandler(IMemberRepository memberRepository, IFileService mediaService, IPackageRepository package)
        {
            _memberRepository = memberRepository;
            _fileService = mediaService;
            _packageRepository = package;
        }

        public async Task<int> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _memberRepository.EmailAndPhoneValdator(request.Email, request.PhoneNo);
                var member = Member.CreateMember(request.FirstName, request.LastName, request.Email, request.PhoneNo, request.DOB);
                var pack = await _packageRepository.GetById(request.PackageId);

                member.ManageMembership(new MembershipData(pack, request.Quantity));

                if (request.ImageFile != null)
                {
                    var url = await _fileService.UploadImage(request.ImageFile, request.LastName, request.PhoneNo);
                    member.PhotoUrl(url);
                }
                await _memberRepository.CreateAsync(member);
                await _memberRepository.SaveChangeAsync();

                return member.MemberId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
    }
}
