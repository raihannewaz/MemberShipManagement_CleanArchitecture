using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Members.Command.DeleteCommand
{
    internal sealed class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, int>
    {
        private readonly IMemberRepository _memberRepository;

        public DeleteMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<int> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var a = await _memberRepository.GetById(request.MemberId);
            await _memberRepository.DeleteAsync(a);
            return a.MemberId;
        }
    }
}
