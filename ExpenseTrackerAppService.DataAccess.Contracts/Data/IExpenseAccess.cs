using ExpenseTrackerAppService.Core.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.DataAccess.Contracts.Data
{
    public interface IExpenseAccess
    {
        public Task<IEnumerable<UserExpense>> GetExpensesOfUserForMonth(string userId, int month, int year);

        public Task<IEnumerable<UserExpense>> GetExpensesOfUserForMonthRange(string userId, int startMonth, int startYear, int endMonth, int endYear);
    }
}
