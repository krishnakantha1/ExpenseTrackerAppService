using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.ControllerModels.Expense
{
    public class ExpenseResponse
    {
        [JsonPropertyName("user_id")]
        public string UserID { get; set; } = string.Empty;

        [JsonPropertyName("expenses")]
        public IEnumerable<ExpenseGroup> ExpenseGroups { get; set; } = Enumerable.Empty<ExpenseGroup>();
    }
}
