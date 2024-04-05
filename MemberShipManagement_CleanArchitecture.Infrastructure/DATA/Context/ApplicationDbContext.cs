using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.Address;
using MemberShipManagement_CleanArchitecture.Infrastructure.Document;
using MemberShipManagement_CleanArchitecture.Infrastructure.Member;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Domain.MemberEntity.Member> Members { get; set; }
        //public DbSet<Domain.DocumentEntity.Document> Documents { get; set; }
        //public DbSet<Domain.AddressEntity.Address> Addresses { get; set; }

        //public DbSet<Domain.MembershipEntity.Membership> Memberships { get; set; }
        //public DbSet<Domain.PackageEntity.Package> Packages { get; set; }
        //public DbSet<Domain.PaymentEntity.Payment> Payments { get; set; }
        //public DbSet<Domain.DuePaymentEntity.DuePayment> DuePayments { get; set; }
        //public DbSet<Domain.PenaltyEntity.Penalty> Penalties { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberTypeConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentTypeConfiguration).Assembly);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AddressTypeConfiguration).Assembly);
        }
    }
}
