using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.AppUserEntity
{
    public class AppUser
    {

        public string? UserName { get; } = "admin";
        public string? Password { get; } = "admin123";

        private AppUser() { }

        public AppUser(string userName, string pass)
        {
            UserName = userName;
            Password = pass;
        }

        public static AppUser LoginDetails(string user, string pass)
        {
            return new AppUser(user, pass);

        }
    }

}
