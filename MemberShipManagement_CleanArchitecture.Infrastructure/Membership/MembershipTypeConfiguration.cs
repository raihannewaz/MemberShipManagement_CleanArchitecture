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

            //builder.HasOne("Member")
            //    .WithMany()
            //    .HasForeignKey("MemberId");

            builder.HasOne("Package")
                .WithMany("Membership")
                .HasForeignKey("PackageId");

            builder.Property<int>("Quantity").IsRequired();
            builder.Property<DateTime>("StartDate").IsRequired();
            builder.Property<DateTime>("EndDate").IsRequired();
            builder.Property<int>("TotalInstallment").IsRequired();
            builder.Property<decimal>("InstallmentAmount").IsRequired();
            



        }
    }
}
