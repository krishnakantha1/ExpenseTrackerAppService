using ExpenseTrackerAppService.Core.Contracts.Utils;
using ExpenseTrackerAppService.Core.Models.ControllerModels.Auth;
using ExpenseTrackerAppService.Core.Models.DataModels;
using ExpenseTrackerAppService.Core.Models.JWTModels;
using ExpenseTrackerAppService.DataAccess.Contracts.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAccess _authAccess;
        private readonly IBCryptProvider _bCryptProvider;
        private readonly IJWTProvider _jwtProvide;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthAccess authAccess,
            IBCryptProvider bCryptProvider,
            IJWTProvider jWTProvider,
            ILogger<AuthController> logger)
        {
            _authAccess = authAccess;
            _bCryptProvider = bCryptProvider;
            _jwtProvide = jWTProvider;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login/")]
        public async Task<IActionResult> Login([FromBody] LoginBody loginBody)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid login request");
                return BadRequest(ModelState);
            }

            User? user = await _authAccess.GetUserFromEmailAsync(loginBody.Email);

            if (user is null)
            {
                return NotFound(new
                {
                    Message = "Email or Password not valid"
                });
            }

            bool validPassword = _bCryptProvider.VerifyPassword(loginBody.Password, user.SaltedPassword);

            if (!validPassword)
            {
                return NotFound(new
                {
                    Message = "Email or Password not valid"
                });
            }

            UserAuthClaims claims = new UserAuthClaims()
            {
                UserId = user.Id,
                UserName = user.Username,
                UserEmail = user.Email,
            };

            string? jwtString = _jwtProvide.GetJWT<UserAuthClaims>(claims);

            if (string.IsNullOrEmpty(jwtString))
            {
                return NotFound(new
                {
                    Message = "jwt not found"
                });
            }

            return Ok(new AuthResponse
            {
                JWT = jwtString
            });
        }
    }
}
