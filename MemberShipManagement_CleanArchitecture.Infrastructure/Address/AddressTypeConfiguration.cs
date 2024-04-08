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
            builder.HasKey(a => a.AddressId);
            builder.Property(a => a.AddressId).UseIdentityColumn();
            builder.Property(a => a.AddressType).IsRequired();
            builder.Property(a => a.HouseNo).IsRequired();
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.Region).IsRequired();
            builder.Property(a => a.PostOffice).IsRequired();
            builder.Property(a => a.Country).IsRequired();
            builder.Property(a => a.PostalCode).IsRequired();

            builder.HasOne(a => a.Member)
                   .WithMany(m => m.Address)
                   .HasForeignKey(a => a.MemberId)
                   .IsRequired();
        }
    }
}
