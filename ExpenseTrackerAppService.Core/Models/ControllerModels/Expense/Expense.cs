using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.ControllerModels.Expense
{
    public class Expense
    {
        [JsonPropertyName("expense_id")]
        public string ExpenseID { get; set; } = string.Empty;

        [JsonPropertyName("amount_encrypted")]
        public string AmountEncripted { get; set; } = string.Empty;

        [JsonPropertyName("bank")]
        public string Bank { get; set; } = string.Empty;

        [JsonPropertyName("expense_date")]
        public DateTime ExpenseDate { get; set; }

        [JsonPropertyName("expense_type")]
        public string ExpenseType { get; set; } = string.Empty;

        [JsonPropertyName("tag")]
        public string ExpenseTag { get; set; } = string.Empty;
    }
}
