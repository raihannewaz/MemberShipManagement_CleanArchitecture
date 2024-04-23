using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
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
            builder.ToTable("Memberships");

            builder.HasKey(m=>m.MembershipId);
            builder.Property(m=>m.MembershipId).UseIdentityColumn();

            builder.HasOne(m=>m.Member)
                .WithMany("Membership")
                .HasForeignKey(m=>m.MemberId);

            builder.HasOne(m => m.Package)
                .WithMany("Membership")
                .HasForeignKey(m => m.PackageId);

            builder.Property(m=>m.Quantity).IsRequired();
            builder.Property(m=>m.StartDate).IsRequired();
            builder.Property(m=>m.EndDate).IsRequired();
            builder.Property(m=>m.TotalInstallment).IsRequired();
            builder.Property(m=>m.InstallmentAmount).IsRequired();
            



        }
    }
}
