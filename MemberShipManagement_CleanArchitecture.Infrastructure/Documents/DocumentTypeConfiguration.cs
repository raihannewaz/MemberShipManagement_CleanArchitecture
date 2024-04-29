

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Documents
{
    internal class DocumentTypeConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {

            builder.ToTable("Documents");

            builder.HasKey(d => d.DocumentId);
            builder.Property(d => d.DocumentId).UseIdentityColumn();

            builder.Property<string>("DocumentType").IsRequired();

            builder.Property<string>("DocumentUrl").IsRequired();

            builder.HasOne("Member")
                   .WithMany("Document")
                   .HasForeignKey("MemberId")
                   .IsRequired();
        }
    }
}
