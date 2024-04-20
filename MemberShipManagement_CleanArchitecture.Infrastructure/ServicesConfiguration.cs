using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using MemberShipManagement_CleanArchitecture.Infrastructure.Member;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberShipManagement_CleanArchitecture.Infrastructure.Address;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.Document;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.Package;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.Membership;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.Payment;
using MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DuePayment;
using MemberShipManagement_CleanArchitecture.Infrastructure.Services.JWT_Services;
using MemberShipManagement_CleanArchitecture.Domain.ServicesInterfaces;

namespace MemberShipManagement_CleanArchitecture.Infrastructure
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DbCon")));


            services.AddTransient<DapperDbContext>();

            services.AddScoped(typeof(IMemberRepository), typeof(MemberRepository));
            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));
            services.AddScoped(typeof(IDocumentRepository), typeof(DocumentRepository));
            services.AddScoped(typeof(IPackageRepository), typeof(PackageRepository));
            services.AddScoped(typeof(IMembershipRepository), typeof(MembershipRepository));
            services.AddScoped(typeof(IPaymentRepository), typeof(PaymentRepository));
            services.AddScoped(typeof(IDuePaymentRepository), typeof(DuePaymentRepository));
            services.AddScoped(typeof(IJwtProvider), typeof(JwtProvider));

            return services;
        }
    }
}
