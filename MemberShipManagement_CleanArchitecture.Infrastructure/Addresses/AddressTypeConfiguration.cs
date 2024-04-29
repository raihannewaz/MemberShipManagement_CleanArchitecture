
namespace MemberShipManagement_CleanArchitecture.Infrastructure.Addresses
{
    internal class AddressTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
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
