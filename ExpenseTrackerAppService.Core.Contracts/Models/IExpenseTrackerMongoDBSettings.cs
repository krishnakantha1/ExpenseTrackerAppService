using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Contracts.Models
{
    public interface IExpenseTrackerMongoDBSettings
    {
        public string DataBaseName { get; set; }
        public string ConnectionString { get; set; }
        public string UserCollectionName { get; set; }
        public string UserExpenseCollectionName { get; set; }
        public string RawCollectionName { get; set; }
    }
}
