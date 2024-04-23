
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Package
{
    internal class PackageTypeConfiguration : IEntityTypeConfiguration<Domain.PackageEntity.Package>
    {
        public void Configure(EntityTypeBuilder<Domain.PackageEntity.Package> builder)
        {
            builder.ToTable("Packages");

            builder.HasKey(p => p.PackageId);
            builder.Property(p => p.PackageId).UseIdentityColumn();

            builder.Property<string>("PackageName").IsRequired().HasMaxLength(30);
            builder.Property<string>("PackageType").IsRequired().HasMaxLength(20);
            builder.Property<int>("Duration").IsRequired();
            builder.Property<decimal>("PackagePrice").IsRequired();
        }
    }
}
