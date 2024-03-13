using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Models.ControllerModels.Expense
{
    public class RangeQueryParam
    {
        [FromQuery(Name = "startMonth")]
        [Range(1, 12, ErrorMessage = "Start month should range from 1 to 12")]
        public int StartMonth { get; set; }

        [FromQuery(Name = "startYear")]
        [Range(1900, 2500, ErrorMessage = "Start year should range from 1900 to 2500")]
        public int StartYear { get; set; }

        [FromQuery(Name = "endMonth")]
        [Range(1, 12, ErrorMessage = "End month should range from 1 to 12")]
        public int EndMonth { get; set; }

        [FromQuery(Name = "endYear")]
        [Range(1900, 2500, ErrorMessage = "End year should range from 1900 to 2500")]
        public int EndYear { get; set; }
    }
}
