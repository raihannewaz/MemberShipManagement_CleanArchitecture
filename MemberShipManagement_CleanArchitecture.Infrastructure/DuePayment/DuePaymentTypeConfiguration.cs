using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.DuePayment
{
    internal class DuePaymentTypeConfiguration : IEntityTypeConfiguration<Domain.DuePaymentEntity.DuePayment>
    {
        public void Configure(EntityTypeBuilder<Domain.DuePaymentEntity.DuePayment> builder)
        {
            builder.ToTable("DuePayments");

            builder.HasKey(m => m.DuePaymentId);
            builder.Property(m => m.DuePaymentId).UseIdentityColumn();

            builder.Property<decimal>("Amount").IsRequired();
            builder.Property<DateTime>("DueDate").IsRequired();


            builder.HasOne("Membership").WithMany("DuePayemnt").HasForeignKey("MembershipId");


        }
    }
}
