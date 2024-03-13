using ExpenseTrackerAppService.Core.Contracts.Models;
using ExpenseTrackerAppService.Core.Models.DataModels;
using ExpenseTrackerAppService.Core.Utils;
using ExpenseTrackerAppService.DataAccess.Contracts.Data;
using ExpenseTrackerAppService.DataAccess.Contracts.DBAccess;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.DataAccess.Data
{
    public class MongoExpenseAccess : IExpenseAccess
    {
        private readonly IExpenseTrackerMongoDBSettings _expenseTrackerMongoDBSettings;
        private readonly IMongoDBDataAccess _mongoDBAccess;

        public MongoExpenseAccess(IExpenseTrackerMongoDBSettings expenseTrackerMongoDBSettings,
            IMongoDBDataAccess mongoDBAccess)
        {
            _expenseTrackerMongoDBSettings = expenseTrackerMongoDBSettings;
            _mongoDBAccess = mongoDBAccess;
        }

        public async Task<IEnumerable<UserExpense>> GetExpensesOfUserForMonth(string userId, int month, int year)
        {
            FilterDefinitionBuilder<UserExpense> filterDefinitionBuilder = Builders<UserExpense>.Filter;

            (int toMonth, int toYear) = DateTimeUtils.AddMonth(year, month, 1);

            DateTime fromDate = new DateTime(year, month, 1);
            DateTime toDate = new DateTime(toYear, toMonth, 1);

            MongoSelect<UserExpense> query = new MongoSelect<UserExpense>(_expenseTrackerMongoDBSettings.UserExpenseCollectionName)
                                                    .Where((ue) => ue.UserId == userId && ue.ExpenseDate >= fromDate && ue.ExpenseDate < toDate);

            IEnumerable<UserExpense> expenses = await _mongoDBAccess.SelectAsync<UserExpense>(query);

            return expenses;
        }

        public async Task<IEnumerable<UserExpense>> GetExpensesOfUserForMonthRange(string userId, int startMonth, int startYear, int endMonth, int endYear)
        {
            (endMonth, endYear) = DateTimeUtils.AddMonth(endYear, endMonth, 1);

            FilterDefinitionBuilder<UserExpense> filterDefinitionBuilder = Builders<UserExpense>.Filter;

            DateTime fromDate = new DateTime(startYear, startMonth, 1);
            DateTime toDate = new DateTime(endYear, endMonth, 1);

            MongoSelect<UserExpense> query = new MongoSelect<UserExpense>(_expenseTrackerMongoDBSettings.UserExpenseCollectionName)
                                                    .Where((ue) => ue.UserId == userId && ue.ExpenseDate >= fromDate && ue.ExpenseDate < toDate);


            IEnumerable<UserExpense> expenses = await _mongoDBAccess.SelectAsync<UserExpense>(query);

            return expenses;
        }
    }
}
