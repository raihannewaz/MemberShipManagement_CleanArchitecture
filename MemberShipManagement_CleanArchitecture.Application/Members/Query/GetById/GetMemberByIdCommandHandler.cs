

namespace MemberShipManagement_CleanArchitecture.Application.Members.Query.GetById
{
    internal sealed class GetMemberByIdCommandHandler : IRequestHandler<GetMemberByIdCommand, IEnumerable<MemberDTO>>
    {
        private readonly IDapperDbContext _dbContext;

        public GetMemberByIdCommandHandler(IDapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MemberDTO>> Handle(GetMemberByIdCommand request, CancellationToken cancellationToken)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                string query = @$"SELECT * FROM Members where MemberId = @MemberId
                      SELECT DocumentType, DocumentUrl From Documents where MemberId = @MemberId
                      SELECT AddressType ,HouseNo ,City,Region,PostOffice,PostalCode,Country From Addresses where MemberId = @MemberId;
                      SELECT PackageId,StartDate,EndDate,Quantity ,TotalInstallment,InstallmentAmount From Memberships where MemberId = @MemberId";

                var result = await conn.QueryMultipleAsync(query, new { MemberId = request.MemberId});

                var member = await result.ReadSingleAsync<MemberDTO>();
                var doc = await result.ReadAsync<DocumentDTO>();
                var address = await result.ReadAsync<AddressDTO>();
                var membership = await result.ReadAsync<MembershipDTO>();

                member.Document = doc.ToList();
                member.Address = address.ToList();
                member.Membership = membership.ToList();

                return new List<MemberDTO> { member };
                
            }
        }
    }
}
