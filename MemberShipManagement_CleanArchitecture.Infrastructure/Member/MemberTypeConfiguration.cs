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
            builder.ToTable("Members");

            builder.HasKey(m => m.MemberId);
            builder.Property(m => m.MemberId).UseIdentityColumn();

            builder.Property(m => m.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.LastName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Email).IsRequired().HasMaxLength(100);
            builder.Property(m => m.PhoneNo).IsRequired().HasMaxLength(11);
            builder.Property(m => m.DOB).IsRequired();
            builder.Property(m => m.AccountCreateDate).IsRequired();

        }
    }
}
