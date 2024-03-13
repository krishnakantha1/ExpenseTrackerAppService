using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.ControllerModels.Auth
{
    public class AuthResponse
    {
        [JsonPropertyName("jwt")]
        public string JWT { get; set; } = string.Empty;
    }
}
