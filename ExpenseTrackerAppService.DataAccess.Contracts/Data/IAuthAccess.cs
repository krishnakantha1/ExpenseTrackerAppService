using ExpenseTrackerAppService.Core.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.DataAccess.Contracts.Data
{
    public interface IAuthAccess
    {
        public Task<User?> GetUserFromEmailAsync(string email);
    }
}
