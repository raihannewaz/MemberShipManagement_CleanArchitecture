using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Query
{
    internal sealed class MemberQueriesHandler : IRequestHandler<MemberQueries, IEnumerable<Member>>
    {
        private readonly IMemberRepository _memberRepository;

        public MemberQueriesHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> Handle(MemberQueries request, CancellationToken cancellationToken)
        {
            switch (request.Query)
            {
                case "MemberDetails":
                    var q = request.MemberDetails(request.MemberId);
                    var data = await _memberRepository.GetByIdSql(q);
                    return data;
                case "AllMembers":
                    var members = await _memberRepository.GetAllAsync(request.AllMembers);
                    return members;
                default:
                    throw new ArgumentException("Invalid query.");
            }
        }
    }
}
