using MediatR;
using MemberShipManagement_CleanArchitecture.Application.Services;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
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

        public CreateMemberCommandHandler(IMemberRepository memberRepository, IFileService mediaService)
        {
            _memberRepository = memberRepository;
            _fileService = mediaService;
        }

        public async Task<int> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var member = Member.CreateMember(request.FirstName, request.LastName, request.Email, request.PhoneNo, request.DOB);
                if (request.ImageFile != null)
                {
                    var url = await _fileService.UploadFile(request.ImageFile);
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
