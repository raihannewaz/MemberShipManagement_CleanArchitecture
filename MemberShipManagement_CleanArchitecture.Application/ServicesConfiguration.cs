
using FluentValidation;
using FluentValidation.AspNetCore;
using MemberShipManagement_CleanArchitecture.Application.Addresses.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.MemberCQRS.MemberValidation;
using MemberShipManagement_CleanArchitecture.Application.Members.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.Members.Command.UpdateCommand;
using MemberShipManagement_CleanArchitecture.Application.Memberships.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.Validation.AddressValidation;
using MemberShipManagement_CleanArchitecture.Application.Validation.MembershipValidation;
using MemberShipManagement_CleanArchitecture.Application.Validation.MemberValidation;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using Microsoft.AspNetCore.Identity;
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
            services.AddScoped<IValidator<CreateMemberCommand>, CreateMemberCommandValidation>();
            services.AddScoped<IValidator<UpdateMemberCommand>, UpdateMemberCommandValidation>();
            services.AddScoped<IValidator<CreateAddressCommand>, CreateAddressCommandValidation>();
            services.AddScoped<IValidator<CreateMembershipCommand>, CreateMembershipCommandValidation>();


            return services;
        }
    }
}
