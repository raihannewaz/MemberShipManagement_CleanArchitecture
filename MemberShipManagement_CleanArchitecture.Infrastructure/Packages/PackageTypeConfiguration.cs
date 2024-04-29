



namespace MemberShipManagement_CleanArchitecture.Infrastructure.Packages
{
    internal class PackageTypeConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
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
