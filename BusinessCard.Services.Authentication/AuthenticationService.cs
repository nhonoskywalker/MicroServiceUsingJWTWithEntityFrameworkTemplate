namespace BusinessCard.Services.Authentication
{
    using BusinessCard.Data.Entities.Users;
    using BusinessCard.Insfrastructure.Messages.LogIn;
    using BusinessCard.Services.Authentication.Processes.LogIn;
    using BusinessCard.Services.AuthToken;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService tokenService;
        private readonly UserManager<UserEntity> userManager;
        private readonly SignInManager<UserEntity> signInManager;

        public AuthenticationService(ITokenService tokenService, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<LogInResponse> AuthenticateUserAsync(LogInRequest request)
        {

            var logInContext = new LogInContext(request, this.tokenService, this.userManager, this.signInManager);
            var result =  await logInContext.ProcessAsync();
            return result;
        }
    }
}
