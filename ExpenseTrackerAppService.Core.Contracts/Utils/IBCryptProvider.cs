using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Contracts.Utils
{
    public interface IBCryptProvider
    {
        public string GetHashedPassword(string password);
        public bool VerifyPassword(string password, string hashedPassword);
    }
}
