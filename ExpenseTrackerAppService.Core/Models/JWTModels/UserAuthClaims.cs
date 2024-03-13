using ExpenseTrackerAppService.Core.Contracts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.JWTModels
{
    public class UserAuthClaims : IClaimsModel
    {
        public bool BindSucessful { get; set; } = false;

        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        public void BindClaims(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public Claim[] GetClaims()
        {
            return new Claim[] {
                new Claim("user-id", UserId),
                new Claim("user-name", UserName),
                new Claim("user-email", UserEmail)
            };
        }
    }
}
