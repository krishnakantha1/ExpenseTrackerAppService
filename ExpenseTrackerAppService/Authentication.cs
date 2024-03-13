using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExpenseTrackerAppService
{
    public static class Authentication
    {
        public static void AddAuth(this WebApplicationBuilder builder)
        {
            string? privateKey = Environment.GetEnvironmentVariable("PRIVATE_KEY");

            if (privateKey is null)
            {
                throw new ArgumentNullException($"{nameof(privateKey)} is null.");
            }

            //builder.Services.ConfigureOptions<JWTBearerOptionsSetup>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                o => o.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    //ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
                    ValidAudience = builder.Configuration["JwtOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(privateKey))
                });

        }
    }
}
