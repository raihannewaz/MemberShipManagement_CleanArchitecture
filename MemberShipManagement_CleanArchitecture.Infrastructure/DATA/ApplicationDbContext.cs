using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.Address;
using MemberShipManagement_CleanArchitecture.Infrastructure.Document;
using MemberShipManagement_CleanArchitecture.Infrastructure.Member;
using MemberShipManagement_CleanArchitecture.Infrastructure.Membership;
using MemberShipManagement_CleanArchitecture.Infrastructure.Package;
using MemberShipManagement_CleanArchitecture.Infrastructure.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.DATA
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> o) : base(o)
        {

        }

        public DbSet<Domain.MemberEntity.Member> Members { get; set; }
        public DbSet<Domain.AddressEntity.Address> Addresses { get; set; }
        public DbSet<Domain.DocumentEntity.Document> Documents { get; set; }
        public DbSet<Domain.PackageEntity.Package> Packages { get; set; }
        public DbSet<Domain.MembershipEntity.Membership> Memberships { get; set; }
        public DbSet<Domain.PaymentEntity.Payment> Payments { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PackageTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MembershipTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
        }



    }
}
