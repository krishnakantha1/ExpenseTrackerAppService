using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Contracts.Utils
{
    public interface IJWTProvider
    {
        public string? GetJWT<C>(C claimsModel) where C : IClaimsModel;
        public C? GetDataFromJWT<C>(C claminsModel, string tokenValue) where C : IClaimsModel;
    }
}
