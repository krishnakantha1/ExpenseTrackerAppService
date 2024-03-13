using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Contracts.Utils
{
    public interface IJWTOptionsSettings
    {
        public string Privatekey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
