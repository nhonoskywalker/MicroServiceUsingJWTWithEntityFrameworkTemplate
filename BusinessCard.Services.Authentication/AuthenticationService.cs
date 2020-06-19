namespace BusinessCard.Services.Authentication
{
    using BusinessCard.Insfrastructure.Messages.LogIn;
    using BusinessCard.Services.Authentication.Processes.LogIn;
    using System.Threading.Tasks;

    public class AuthenticationService : IAuthenticationService
    {
        public Task<LogInResponse> AuthenticateUserAsync(LogInRequest request)
        {

            var context = new LogInContext();

            return context.ProcessAsync();
        }
    }
}
