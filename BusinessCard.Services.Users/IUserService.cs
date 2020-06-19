namespace BusinessCard.Services.Users
{
    using BusinessCard.Insfrastructure.Messages.UserRegistration;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<UserRegistrationResponse> RegisterUserAsync(UserRegistrationRequest request);
    }
}
