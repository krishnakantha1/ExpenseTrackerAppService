using ExpenseTrackerAppService.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.DataModels
{
    public class ExpenseTrackerMongoDBSettings : IExpenseTrackerMongoDBSettings
    {
        public string DataBaseName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string UserCollectionName { get; set; } = string.Empty;
        public string UserExpenseCollectionName { get; set; } = string.Empty;
        public string RawCollectionName { get; set; } = string.Empty;
    }
}
