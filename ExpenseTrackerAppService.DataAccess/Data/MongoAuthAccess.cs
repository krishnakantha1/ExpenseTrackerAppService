using ExpenseTrackerAppService.Core.Contracts.Models;
using ExpenseTrackerAppService.Core.Models.DataModels;
using ExpenseTrackerAppService.DataAccess.Contracts.Data;
using ExpenseTrackerAppService.DataAccess.Contracts.DBAccess;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.DataAccess.Data
{
    public class MongoAuthAccess : IAuthAccess
    {
        private readonly IExpenseTrackerMongoDBSettings _settings;
        private readonly IMongoDBDataAccess _mongoDBAccess;

        public MongoAuthAccess(IExpenseTrackerMongoDBSettings settings,
            IMongoDBDataAccess mongoDBAccess)
        {
            _settings = settings;
            _mongoDBAccess = mongoDBAccess;
        }


        public async Task<User?> GetUserFromEmailAsync(string email)
        {
            FilterDefinitionBuilder<User> filterDefinitionBuilder = Builders<User>.Filter;

            MongoSelect<User> query = new MongoSelect<User>(_settings.UserCollectionName)
                                             .Where((u) => u.Email == email);

            IEnumerable<User> user = await _mongoDBAccess.SelectAsync<User>(query);

            return user.FirstOrDefault<User>();
        }
    }
}
