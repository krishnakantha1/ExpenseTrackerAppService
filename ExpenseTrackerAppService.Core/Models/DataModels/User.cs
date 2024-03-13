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
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = String.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("password")]
        public string SaltedPassword { get; set; } = String.Empty;

        [BsonElement("created_on")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("updated_on")]
        public DateTime ModifiedOn { get; set; }

        [BsonElement("aestest")]
        public string AESTest { get; set; } = String.Empty;
    }
}
