

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Payments
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.PaymentId);
            builder.Property(p => p.PaymentId).UseIdentityColumn();


            builder.Property<decimal>("PaidAmmount").IsRequired();
            builder.Property<int>("AdvanceInstallMent").IsRequired();
            builder.Property<DateTime>("PaymentDate").IsRequired();
        }
    }
}
