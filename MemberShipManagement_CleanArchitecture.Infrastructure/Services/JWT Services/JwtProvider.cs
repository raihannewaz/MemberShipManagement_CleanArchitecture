

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Services.JWT_Services
{
    internal class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public JwtProvider(IConfiguration config)
        {
            this._config = config;
            this._key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }

        public string CreateToken(AppUser appUser)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, appUser.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
                Issuer = _config["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }
    }
}
