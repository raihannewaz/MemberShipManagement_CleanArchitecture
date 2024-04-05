using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Command.CreateCommand
{
    internal sealed class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
    {
        private readonly IMemberRepository _memberRepository;

        public CreateMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = Member.CreateMember(request.FirstName, request.LastName,request.Email,request.PhoneNo,request.DOB,request.ImageFile);
            //var image = await _memberRepository.UploadImageAsync(request.ImageFile);
            await _memberRepository.CreateAsync(member);
            return member;
        }
    }
}
