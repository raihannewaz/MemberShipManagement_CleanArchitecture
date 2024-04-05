
using FluentValidation.AspNetCore;
using MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Validation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


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
            services.AddFluentValidationClientsideAdapters();

            return services;
        }
    }
}
