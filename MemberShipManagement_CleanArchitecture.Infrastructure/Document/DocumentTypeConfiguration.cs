
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Document
{
    internal class DocumentTypeConfiguration : IEntityTypeConfiguration<Domain.DocumentEntity.Document>
    {
        public void Configure(EntityTypeBuilder<Domain.DocumentEntity.Document> builder)
        {
            builder.HasKey(d => d.DocumentId);
            builder.Property(d => d.DocumentId).UseIdentityColumn();

            builder.Property(d => d.DocumentType).IsRequired();

            builder.Property(d => d.DocumentUrl).IsRequired();

            builder.HasOne(d => d.Member)
                   .WithMany(m => m.Document)
                   .HasForeignKey(d => d.MemberId)
                   .IsRequired();
        }
    }
}
