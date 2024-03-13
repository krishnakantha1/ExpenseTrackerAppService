using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.ControllerModels.Auth
{
    public class LoginBody
    {
        [Required(ErrorMessage = "Email is a mandatory parameter.")]
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is a mandatory parameter.")]
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}
