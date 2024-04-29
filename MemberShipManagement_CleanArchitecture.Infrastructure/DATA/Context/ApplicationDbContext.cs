

namespace MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> o) : base(o)
        {
        }


        public DbSet<Member> Members { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DuePayment> DuePayments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PackageTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
        }



    }
}
