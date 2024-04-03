using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Membership
{
    internal class MembershipTypeConfiguration : IEntityTypeConfiguration<Domain.MembershipEntity.Membership>
    {
        public void Configure(EntityTypeBuilder<Domain.MembershipEntity.Membership> builder)
        {
            throw new NotImplementedException();
        }
    }
}
