using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.DataModels
{
    [BsonIgnoreExtraElements]
    public class UserExpense
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("uri")]
        public string Uri { get; set; } = string.Empty;

        [BsonElement("user_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = string.Empty;

        [BsonElement("amount_encrypted")]
        public string AmountEncripted { get; set; } = string.Empty;

        [BsonElement("bank")]
        public string Bank { get; set; } = string.Empty;

        [BsonElement("expense_date")]
        public DateTime ExpenseDate { get; set; }

        [BsonElement("expense_type")]
        public string ExpenseType { get; set; } = String.Empty;

        [BsonElement("tag")]
        public string ExpenseTag { get; set; } = String.Empty;

        [BsonElement("updated_on")]
        public DateTime LastUpdatedOn { get; set; }
    }
}
