using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.ControllerModels.Expense
{
    public class MonthQueryParam
    {

        [Range(1, 12, ErrorMessage = "Month should range from 1 to 12")]
        [FromQuery(Name = "month")]
        public int Month { get; set; }

        [Range(1900, 2500, ErrorMessage = "Year should range from 1900 to 2500")]
        [FromQuery(Name = "year")]
        public int Year { get; set; }
    }
}
