
namespace MemberShipManagement_CleanArchitecture.Application
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<CreateMemberCommand>, CreateMemberCommandValidation>();
            services.AddScoped<IValidator<UpdateMemberCommand>, UpdateMemberCommandValidation>();
            services.AddScoped<IValidator<CreateAddressCommand>, CreateAddressCommandValidation>();
         


            return services;
        }
    }
}
