using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.AppUserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.AppUserCQRS.Command.LoginCommand
{
    public class AppUserLoginCommand: IRequest<string>
    {
        public string? UserName { get; }
        public string? Password { get; }
    }
}
