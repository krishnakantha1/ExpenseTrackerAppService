using ExpenseTrackerAppService.Core.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.DataAccess.Contracts.DBAccess
{
    public interface IMongoDBDataAccess
    {
        public Task<IEnumerable<C>> SelectAsync<C>(MongoSelect<C> query);

        public Task<int> UpdateAsync<C>(MongoUpdate query);

        public Task<int> DeleteAsync<C>(MongoDelete query);

        public Task<bool> InsertAsync<C>(MongoInsert<C> query);
    }
}
