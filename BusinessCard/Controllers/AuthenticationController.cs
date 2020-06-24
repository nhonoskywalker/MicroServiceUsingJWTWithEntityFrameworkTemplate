namespace BusinessCard.Controllers
{
    using BusinessCard.Extensions;
    using BusinessCard.Extensions.Messages;
    using BusinessCard.Filters;
    using BusinessCard.Messages.Authentication;
    using BusinessCard.Services.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [ServiceFilter(typeof(LogExceptionAttribute))]
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LogInWebRequest webRequest)
        {
            var result = await this.authenticationService.AuthenticateUserAsync(webRequest.AsRequest());

            return this.CreateResponse(result.AsWebResponse());
        }
    }
}
