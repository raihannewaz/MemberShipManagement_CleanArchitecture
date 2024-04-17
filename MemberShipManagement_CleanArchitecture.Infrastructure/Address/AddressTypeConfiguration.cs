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

            builder.Property(a => a.AddressType).IsRequired().HasMaxLength(20);
            builder.Property(a => a.HouseNo).IsRequired().HasMaxLength(100);
            builder.Property(a => a.City).IsRequired().HasMaxLength(15);
            builder.Property(a => a.Region).IsRequired().HasMaxLength(15);
            builder.Property(a => a.PostOffice).IsRequired().HasMaxLength(15);
            builder.Property(a => a.PostalCode).IsRequired().HasMaxLength(15);
            builder.Property(a => a.Country).IsRequired().HasMaxLength(20);

            builder.HasOne(a => a.Member)
                   .WithMany(m => m.Address)
                   .HasForeignKey(a => a.MemberId)
                   .IsRequired();
        }
    }
}
