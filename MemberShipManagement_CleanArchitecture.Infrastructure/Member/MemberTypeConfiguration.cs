using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Member
{
    internal class MemberTypeConfiguration : IEntityTypeConfiguration<Domain.MemberEntity.Member>
    {
        public void Configure(EntityTypeBuilder<Domain.MemberEntity.Member> builder)
        {
            throw new NotImplementedException();
        }
    }
}
