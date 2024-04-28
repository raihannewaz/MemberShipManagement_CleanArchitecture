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

            builder.Property<string>("FirstName").IsRequired().HasMaxLength(50);
            builder.Property<string>("LastName").IsRequired().HasMaxLength(50);
            builder.Property<string>("Email").IsRequired().HasMaxLength(100);
            builder.Property<string>("PhoneNo").IsRequired().HasMaxLength(11);
            builder.Property<string>("ProfileImageUrl").IsRequired().HasMaxLength(11);
            builder.Property<bool>("IsActive").IsRequired().HasMaxLength(11);
            builder.Property<DateTime>("DOB").IsRequired();
            builder.Property<DateTime>("AccountCreateDate").IsRequired();
            builder.HasMany("Memberships")
                  .WithOne()
                  .HasForeignKey("MemberId");

        }
    }
}
