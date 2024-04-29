

namespace MemberShipManagement_CleanArchitecture.Infrastructure.DuePayments
{
    internal class DuePaymentTypeConfiguration : IEntityTypeConfiguration<DuePayment>
    {
        public void Configure(EntityTypeBuilder<DuePayment> builder)
        {
            builder.ToTable("DuePayments");

            builder.HasKey(m => m.DuePaymentId);
            builder.Property(m => m.DuePaymentId).UseIdentityColumn();

            builder.Property<decimal>("Amount").IsRequired();
            builder.Property<DateTime>("DueDate").IsRequired();


            builder.HasOne("Membership").WithMany("DuePayemnt").HasForeignKey("MembershipId");


        }
    }
}
