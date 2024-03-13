using ExpenseTrackerAppService.Core.Models.ControllerModels.Expense;
using ExpenseTrackerAppService.Core.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Utils
{
    public class ExpenseResponseBuilder
    {
        private ExpenseResponse expenseResponse { get; set; }

        private List<ExpenseGroup> expenseGroups { get; set; }

        //this is used to deterimine the index of the expenseGroup that coresponds to the given year, month.
        Dictionary<int, Dictionary<int, int>> expenseGroupMap { get; set; }

        public ExpenseResponseBuilder(string userId)
        {
            expenseResponse = new ExpenseResponse()
            {
                UserID = userId,
            };
            expenseGroups = new();
            expenseGroupMap = new();
        }

        public ExpenseResponseBuilder AddExpense(UserExpense expense)
        {
            int year = expense.ExpenseDate.Year;
            int month = expense.ExpenseDate.Month;

            if (expenseGroupMap.ContainsKey(year))
            {
                var dictMonth = expenseGroupMap[year];
                if (dictMonth.ContainsKey(month))
                {
                    int groupIdx = dictMonth[month];
                    expenseGroups[groupIdx].Expenses.Add(GetExpenseFromUserExpense(expense));
                }
                else
                {
                    int groupIdx = expenseGroups.Count;
                    ExpenseGroup expenseGroup = new ExpenseGroup()
                    {
                        Year = year,
                        Month = month,
                    };
                    expenseGroup.Expenses.Add(GetExpenseFromUserExpense(expense));
                    expenseGroups.Add(expenseGroup);

                    expenseGroupMap[year][month] = groupIdx;
                }
            }
            else
            {
                int groupIdx = expenseGroups.Count;
                ExpenseGroup expenseGroup = new ExpenseGroup()
                {
                    Year = year,
                    Month = month,
                };
                expenseGroup.Expenses.Add(GetExpenseFromUserExpense(expense));
                expenseGroups.Add(expenseGroup);

                expenseGroupMap[year] = new();
                expenseGroupMap[year][month] = groupIdx;
            }

            return this;
        }

        public ExpenseResponseBuilder AddExpenseRange(IEnumerable<UserExpense> expenses)
        {

            foreach (UserExpense expense in expenses)
            {
                AddExpense(expense);
            }

            return this;
        }

        public ExpenseResponse Build()
        {
            expenseResponse.ExpenseGroups = expenseGroups;
            return expenseResponse;
        }

        private Expense GetExpenseFromUserExpense(UserExpense userExpense)
        {
            return new Expense()
            {
                ExpenseID = userExpense.Id,
                AmountEncripted = userExpense.AmountEncripted,
                Bank = userExpense.Bank,
                ExpenseDate = userExpense.ExpenseDate,
                ExpenseType = userExpense.ExpenseType,
                ExpenseTag = userExpense.ExpenseTag,
            };
        }
    }
}
