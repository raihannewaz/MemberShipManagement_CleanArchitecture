using MediatR;
using MemberShipManagement_CleanArchitecture.Application.Services;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Members.Command.UpdateCommand
{
    internal sealed class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, int>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IFileService _fileService;

        public UpdateMemberCommandHandler(IMemberRepository memberRepository, IFileService fileService)
        {
            _memberRepository = memberRepository;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {

            var member = await _memberRepository.GetById(request.MemberId);
            if (member == null)
            {
                throw new ArgumentException($"Member with ID {request.MemberId} not found.");
            }
            member.UpdateMember(request.FirstName, request.LastName, request.Email, request.PhoneNo, request.DOB, request.IsActive);

            if (request.ImageFile != null)
            {
                _fileService.UpdateFile(member.GetProfileImageUrl());
                var url = await _fileService.UploadFile(request.ImageFile);
                member.PhotoUrl(url);
            }

            await _memberRepository.UpdateAsync(member);

            await _memberRepository.SaveChangeAsync();

            return request.MemberId;
        }
    }
}
