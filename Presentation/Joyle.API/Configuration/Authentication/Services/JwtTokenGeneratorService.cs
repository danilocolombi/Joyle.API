using Joyle.Accounts.Application.Authentication.Authenticate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Joyle.API.Configuration.Authentication.Services
{
    public class JwtTokenGeneratorService : IJwtTokenGeneratorService
    {
        private readonly AuthenticationSettings _authSettings;
        public JwtTokenGeneratorService(IOptions<AuthenticationSettings> authSettings)
        {
            _authSettings = authSettings.Value;
        }
        public string Generate(LoginDto user)
        {
            var identityClaims = GenerateClaims(user);
            var encodedToken = CreateToken(identityClaims);

            return encodedToken;
        }

        private ClaimsIdentity GenerateClaims(LoginDto user)
        {
            var defaultClaims = GenerateDefaultClaims(user);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(defaultClaims);

            return identityClaims;
        }

        private IEnumerable<Claim> GenerateDefaultClaims(LoginDto user)
        {
            var claims = new List<Claim>(5);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.Username));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            return claims;
        }

        private string CreateToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _authSettings.Issuer,
                Audience = _authSettings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_authSettings.ExpirationInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        private static long ToUnixEpochDate(DateTime date)
           => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
