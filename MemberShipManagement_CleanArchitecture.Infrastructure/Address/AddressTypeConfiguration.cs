using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Address
{
    internal class AddressTypeConfiguration : IEntityTypeConfiguration<Domain.AddressEntity.Address>
    {
        public void Configure(EntityTypeBuilder<Domain.AddressEntity.Address> builder)
        {

            builder.ToTable("Addresses");

            builder.HasKey(a => a.AddressId);
            builder.Property(a => a.AddressId).UseIdentityColumn();

            builder.Property<string>("AddressType").IsRequired().HasMaxLength(20);
            builder.Property<string>("HouseNo").IsRequired().HasMaxLength(100);
            builder.Property<string>("City").IsRequired().HasMaxLength(15);
            builder.Property<string>("Region").IsRequired().HasMaxLength(15);
            builder.Property<string>("PostOffice").IsRequired().HasMaxLength(15);
            builder.Property<string>("PostalCode").IsRequired().HasMaxLength(15);
            builder.Property<string>("Country").IsRequired().HasMaxLength(20);

            builder.HasOne("Member")
                   .WithMany("Address")
                   .HasForeignKey("MemberId")
                   .IsRequired();
        }
    }
}
