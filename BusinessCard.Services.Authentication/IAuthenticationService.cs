namespace BusinessCard.Services.Authentication
{
    using BusinessCard.Insfrastructure.Messages.LogIn;
    using System.Threading.Tasks;

    public interface IAuthenticationService
    {
        Task<LogInResponse> AuthenticateUserAsync(LogInRequest request);
    }
}
