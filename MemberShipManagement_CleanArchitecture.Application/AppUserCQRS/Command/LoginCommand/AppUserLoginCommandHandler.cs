using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.AppUserEntity;
using MemberShipManagement_CleanArchitecture.Domain.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.AppUserCQRS.Command.LoginCommand
{
    internal sealed class AppUserLoginCommandHandler : IRequestHandler<AppUserLoginCommand, string>
    {
        public readonly IJwtProvider _jwtProvider;

        public AppUserLoginCommandHandler(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Handle(AppUserLoginCommand request, CancellationToken cancellationToken)
        {

            var data = AppUser.LoginDetails(request.UserName, request.Password);
            var token = _jwtProvider.CreateToken(data);
            return token;

        }
    }
}
