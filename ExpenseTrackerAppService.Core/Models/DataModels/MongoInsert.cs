using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.DataModels
{
    public class MongoInsert<C>
    {
        public string CollectionName { get; set; } = string.Empty;

        public List<C> CollectionItems { get; set; } = new List<C>();
    }
}
