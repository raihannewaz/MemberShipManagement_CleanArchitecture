
namespace MemberShipManagement_CleanArchitecture.Infrastructure.Members
{
    internal class MemberTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder.HasKey(m => m.MemberId);
            builder.Property(m => m.MemberId).UseIdentityColumn();

            builder.Property<string>("FirstName").IsRequired().HasMaxLength(50);
            builder.Property<string>("LastName").IsRequired().HasMaxLength(50);
            builder.Property<string>("Email").IsRequired().HasMaxLength(100);
            builder.Property<string>("PhoneNo").IsRequired().HasMaxLength(11);
            builder.Property<string>("ProfileImageUrl").IsRequired().HasMaxLength(11);
            builder.Property<bool>("IsActive").IsRequired().HasMaxLength(11);
            builder.Property<DateTime>("DOB").IsRequired();
            builder.Property<DateTime>("AccountCreateDate").IsRequired();


            builder.OwnsMany<Membership>("Memberships", m =>
            {
                m.ToTable("Memberships");
                m.HasKey(i => i.MembershipId);
                m.WithOwner().HasForeignKey(f => f.MemberId);

                m.Property<int>("Quantity").IsRequired();
                m.Property<DateTime>("StartDate").IsRequired();
                m.Property<DateTime>("EndDate").IsRequired();
                m.Property<int>("TotalInstallment").IsRequired();
                m.Property<decimal>("InstallmentAmount").IsRequired();

              
            });
        }
    }
}
