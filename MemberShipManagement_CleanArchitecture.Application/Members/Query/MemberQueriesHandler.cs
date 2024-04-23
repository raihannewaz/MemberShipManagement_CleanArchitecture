using MediatR;
using MemberShipManagement_CleanArchitecture.Application.DTO_s;
using MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MemberShipManagement_CleanArchitecture.Application.Members.Query
{
    internal sealed class MemberQueriesHandler : IRequestHandler<MemberQueries, IEnumerable<MemberDTO>>
    {
        private readonly IMemberRepository _memberRepository;

        public MemberQueriesHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<MemberDTO>> Handle(MemberQueries request, CancellationToken cancellationToken)
        {
            switch (request.Query)
            {
                //case "MemberDetails":
                //    var q = request.MemberDetails(request.MemberId);
                //    var data = await _memberRepository.GetByIdSql(q);
                //    return data as IEnumerable<MemberDTO>;
                //case "AllMembers":
                //    var members = await _memberRepository.GetAllAsync(request.AllMembers);
                //    return members;
                default:
                    throw new ArgumentException("Invalid query.");
            }
        }
    }
}
