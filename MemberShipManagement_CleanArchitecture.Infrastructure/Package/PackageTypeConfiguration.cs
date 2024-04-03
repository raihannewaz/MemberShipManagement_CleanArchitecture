
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
            throw new NotImplementedException();
        }
    }
}
