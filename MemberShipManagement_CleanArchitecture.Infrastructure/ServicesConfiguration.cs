

namespace MemberShipManagement_CleanArchitecture.Infrastructure
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DbCon")));

            services.AddHostedService<DuePaymentCheckService>();

            //services.AddTransient<IDapperDbContext, DapperDbContext>();
            services.AddScoped(typeof(IDapperDbContext), typeof(DapperDbContext));

            services.AddScoped(typeof(IMemberRepository), typeof(MemberRepository));
            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));
            services.AddScoped(typeof(IDocumentRepository), typeof(DocumentRepository));
            services.AddScoped(typeof(IPackageRepository), typeof(PackageRepository));
            services.AddScoped(typeof(IPaymentRepository), typeof(PaymentRepository));
            services.AddScoped(typeof(IDuePaymentRepository), typeof(DuePaymentRepository));
            services.AddScoped(typeof(IJwtProvider), typeof(JwtProvider));
            services.AddScoped(typeof(IFileService), typeof(FileService));


            return services;
        }
    }
}
