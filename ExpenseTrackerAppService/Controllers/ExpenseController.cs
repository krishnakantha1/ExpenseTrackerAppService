using ExpenseTrackerAppService.Core.Models.ControllerModels.Expense;
using ExpenseTrackerAppService.Core.Utils;
using ExpenseTrackerAppService.DataAccess.Contracts.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTrackerAppService.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseAccess _expenseAccess;
        private readonly ILogger<ExpenseController> _logger;

        public ExpenseController(IExpenseAccess expenseAccess,
            ILogger<ExpenseController> logger)
        {
            _expenseAccess = expenseAccess;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        [Route("monthly/")]
        public async Task<IActionResult> GetExpenseByMonth([FromQuery] MonthQueryParam monthlyQueryParam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var claimsIdentity = User.Identity as ClaimsIdentity;

            string? userID = claimsIdentity?.FindFirst("user-id")?.Value;

            if (string.IsNullOrEmpty(userID))
            {
                return NotFound("user not found");
            }

            var expenses = await _expenseAccess.GetExpensesOfUserForMonth(userID, monthlyQueryParam.Month, monthlyQueryParam.Year);

            var responseBuilder = new ExpenseResponseBuilder(userID);
            var response = responseBuilder.AddExpenseRange(expenses).Build();

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("range/")]
        public async Task<IActionResult> GetExpenseByRange([FromQuery] RangeQueryParam rangeQueryParam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var claimsIdentity = User.Identity as ClaimsIdentity;

            string? userID = claimsIdentity?.FindFirst("user-id")?.Value;

            if (string.IsNullOrEmpty(userID))
            {
                return NotFound("user not found");
            }

            var expense = await _expenseAccess.GetExpensesOfUserForMonthRange(userID, rangeQueryParam.StartMonth, rangeQueryParam.StartYear, rangeQueryParam.EndMonth, rangeQueryParam.EndYear);

            var responseBuilder = new ExpenseResponseBuilder(userID);
            var response = responseBuilder.AddExpenseRange(expense).Build();

            return Ok(response);
        }
    }
}
