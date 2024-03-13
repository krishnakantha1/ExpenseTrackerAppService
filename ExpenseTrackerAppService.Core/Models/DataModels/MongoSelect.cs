using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.DataModels
{
    public class MongoSelect<C>
    {
        public string CollectionName { get; set; }

        public MongoSelect(string collectionName)
        {
            CollectionName = collectionName;
        }
        public Expression<Func<C, bool>> Filter { get; set; } = (C) => false;

        public MongoSelect<C> Where(Expression<Func<C, bool>> predicate)
        {
            Filter = predicate;
            return this;
        }
    }
}
