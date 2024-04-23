using MemberShipManagement_CleanArchitecture.Domain.AppUserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.Services
{
    public interface IJwtProvider
    {
        string CreateToken(AppUser appUser);
    }
}
