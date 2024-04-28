using MediatR;
using MemberShipManagement_CleanArchitecture.Application.DTO_s;
using MemberShipManagement_CleanArchitecture.Application.Services;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Members.Command.CreateCommand
{
    internal sealed class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, int>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IFileService _fileService;
        private readonly IPackageRepository _packageRepository;
        private readonly IMembershipRepository _membershipRepository;

        public CreateMemberCommandHandler(IMemberRepository memberRepository, IFileService mediaService, IPackageRepository package,IMembershipRepository membershipRepository)
        {
            _memberRepository = memberRepository;
            _fileService = mediaService;
            _packageRepository = package;
            _membershipRepository = membershipRepository;
        }

        public async Task<int> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var member = Member.CreateMember(request.FirstName, request.LastName, request.Email, request.PhoneNo, request.DOB);
                if (request.ImageFile != null)
                {
                    var url = await _fileService.UploadImage(request.ImageFile, request.LastName, request.PhoneNo);
                    member.PhotoUrl(url);
                }
                await _memberRepository.CreateAsync(member);
                await _memberRepository.SaveChangeAsync();

                if (request.PackageId >= 0 && request.Quantity > 0)
                {
                    var pack = await _packageRepository.GetById(request.PackageId);
                    var membership = Membership.CreateMembership(member.MemberId,request.PackageId, request.Quantity);
                    membership.AssignPackage(pack);
                    await _membershipRepository.CreateAsync(membership);
                    await _membershipRepository.SaveChangeAsync();
                }


                return member.MemberId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
    }
}
