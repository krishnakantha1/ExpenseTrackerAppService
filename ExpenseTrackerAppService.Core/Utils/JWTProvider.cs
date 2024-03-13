using ExpenseTrackerAppService.Core.Contracts.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Utils
{
    public class JWTProvider : IJWTProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IJWTOptionsSettings _settings;

        public JWTProvider(IConfiguration configuration, IJWTOptionsSettings settings)
        {
            _configuration = configuration;
            _settings = settings;
        }

        public C? GetDataFromJWT<C>(C claminsModel, string tokenValue) where C : IClaimsModel
        {
            throw new NotImplementedException();
        }

        public string? GetJWT<C>(C claimsModel) where C : IClaimsModel
        {

            string secreteString = _settings.Privatekey;
            if (string.IsNullOrEmpty(secreteString))
            {
                throw new Exception("Secrete for siging JWT is missing.");
            }

            var securtyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteString));

            Claim[] claims = claimsModel.GetClaims();

            var signingCreditials = new SigningCredentials(securtyKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _settings.Issuer,
                _settings.Audience,
                claims,
                null,
                DateTime.UtcNow.AddDays(10),
                signingCreditials);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
