using ExpenseTrackerAppService.Core.Contracts.Models;
using ExpenseTrackerAppService.Core.Models.DataModels;
using ExpenseTrackerAppService.DataAccess.Contracts.DBAccess;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.DataAccess.DBAccess
{
    public class MongoDBDataAccess : IMongoDBDataAccess
    {
        private readonly IMongoDatabase _database;
        public MongoDBDataAccess(IExpenseTrackerMongoDBSettings settings, IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase(settings.DataBaseName);
        }

        public Task<int> DeleteAsync<C>(MongoDelete query)
        {
            IMongoCollection<C> collection = _database.GetCollection<C>(query.CollectionName);

            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync<C>(MongoInsert<C> query)
        {
            IMongoCollection<C> collection = _database.GetCollection<C>(query.CollectionName);

            if (query.CollectionItems.Count == 0)
            {
                throw new Exception($"Got no items to insert into {nameof(C)} collection");
            }

            if (query.CollectionItems.Count == 1)
            {
                await collection.InsertOneAsync(query.CollectionItems[0]);
            }
            else
            {
                await collection.InsertManyAsync(query.CollectionItems);
            }

            return true;
        }

        public async Task<IEnumerable<C>> SelectAsync<C>(MongoSelect<C> query)
        {
            IMongoCollection<C> collection = _database.GetCollection<C>(query.CollectionName);

            IAsyncCursor<C> cursor = await collection.FindAsync<C>(query.Filter);

            return await cursor.ToListAsync();
        }

        public Task<int> UpdateAsync<C>(MongoUpdate query)
        {
            IMongoCollection<C> collection = _database.GetCollection<C>(query.CollectionName);

            throw new NotImplementedException();
        }
    }
}
