using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Contracts.Utils
{
    public interface IClaimsModel
    {
        public bool BindSucessful { get; set; }
        public Claim[] GetClaims();
        public void BindClaims(IEnumerable<Claim> claims);
    }
}
