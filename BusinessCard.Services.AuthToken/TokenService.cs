namespace BusinessCard.Services.AuthToken
{
    using BusinessCard.Data.Entities.Users;
    using BusinessCard.Insfrastructure.Providers;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class TokenService : ITokenService
    {
        private readonly IJwtOptionsProvider jwtOptions;

        public TokenService(IJwtOptionsProvider jwtOptions)
        {
            this.jwtOptions = jwtOptions;
        }

        public string GenerateToken(UserEntity userEntity, IList<string> roles)
        {
            var token = string.Empty;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtOptions.GetJwtOptions().Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userEntity.UserName),
                new Claim(ClaimTypes.GivenName, userEntity.FirstName),
                new Claim(ClaimTypes.Surname, userEntity.LastName),
                new Claim(ClaimTypes.NameIdentifier, userEntity.Id.ToString())
            };

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(this.jwtOptions.GetJwtOptions().ExpiresInMinutes),
                SigningCredentials = credentials
            };

            token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return token;
        }
    }
}
