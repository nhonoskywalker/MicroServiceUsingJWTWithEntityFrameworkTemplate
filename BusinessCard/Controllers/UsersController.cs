namespace BusinessCard.Controllers
{
    using BusinessCard.Extensions;
    using BusinessCard.Extensions.Messages;
    using BusinessCard.Messages.Users;
    using BusinessCard.Services.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegistrationWebRequest webRequest)
        {
            var result = await this.userService.RegisterUserAsync(webRequest.AsRequest());

            return this.CreateResponse(result.AsWebResponse());
        }
    }
}
