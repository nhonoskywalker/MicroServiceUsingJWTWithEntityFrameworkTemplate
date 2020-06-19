namespace BusinessCard.Services.Users
{
    using BusinessCard.Data.Entities.Users;
    using BusinessCard.Insfrastructure.Messages.UserRegistration;
    using BusinessCard.Services.Users.Processes.UserRegistration;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> userManager;
        private readonly RoleManager<RoleEntity> roleManager;

        public UserService(UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<UserRegistrationResponse> RegisterUserAsync(UserRegistrationRequest request)
        {
            var userRegistrationContext = new UserRegistrationContext(request, this.userManager, this.roleManager);
            var result = await userRegistrationContext.ProcessAsync();
            return result;
        }
    }
}
