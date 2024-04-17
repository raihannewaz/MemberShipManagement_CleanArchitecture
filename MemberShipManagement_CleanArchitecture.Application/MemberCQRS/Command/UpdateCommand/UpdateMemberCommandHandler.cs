using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Command.UpdateCommand
{
    internal sealed class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, int>
    {
        private readonly IMemberRepository _memberRepository;

        public UpdateMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<int> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetById(request.MemberId);
            if (member == null)
            {
                throw new ArgumentException($"Member with ID {request.MemberId} not found.");
            }
            member.UpdateMember(request.FirstName, request.LastName, request.Email, request.PhoneNo,request.DOB, request.ImageFile, request.IsActive);
            
            await _memberRepository.UpdateAsync(member);
            await _memberRepository.SaveChangeAsync();

            return request.MemberId;
        }
    }
}
