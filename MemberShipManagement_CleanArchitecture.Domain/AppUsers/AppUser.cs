using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.AppUsers
{
    public class AppUser
    {

        public string? UserName {  get; set; }
        public string? Password {  get; set; }


        private AppUser() { }

        private AppUser(string userName, string pass)
        {
            if (userName == "admin" && pass == "admin123")
            {
                UserName = userName;
                Password = pass;
            }
            else
            {
                throw new ArgumentException("not matched");
            }

        }

        public static AppUser LoginDetails(string user, string pass)
        {
            return new AppUser(user, pass);

        }
    }

}
