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
            builder.Property(m => m.MemberId).ValueGeneratedOnAdd();

            builder.Property(m => m.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.LastName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Email).IsRequired().HasMaxLength(100);
            builder.Property(m => m.PhoneNo).IsRequired().HasMaxLength(11);
            builder.Property(m => m.DOB).IsRequired();
            builder.Property(m => m.AccountCreateDate).IsRequired();

            builder.HasCheckConstraint("CK_Member_PhoneNo_StartsWith", "[PhoneNo] LIKE '018%' OR [PhoneNo] LIKE '017%' OR [PhoneNo] LIKE '016%' OR [PhoneNo] LIKE '019%' OR [PhoneNo] LIKE '013%' OR [PhoneNo] LIKE '014%' OR [PhoneNo] LIKE '015%'");
            builder.HasCheckConstraint("CK_Member_DOB_MinimumAge", "[DOB] <= DATEADD(year, -18, GETDATE())");

        }
    }
}
