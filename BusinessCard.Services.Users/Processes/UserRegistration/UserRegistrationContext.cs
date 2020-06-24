namespace BusinessCard.Services.Users.Processes.UserRegistration
{
    using BusinessCard.Data.Entities.Users;
    using BusinessCard.Insfrastructure.Messages.UserRegistration;
    using BusinessCard.Insfrastructure.Processes;
    using BusinessCard.Services.Users.Enums;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class UserRegistrationContext : ProcessContext<UserRegistrationResponse>
    {

        public UserRegistrationContext(UserRegistrationRequest request,  UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager)
        {
            this.RoleManager = roleManager;
            this.UserManager = userManager;
            this.Request = request;
            this.Result = new UserRegistrationResponse();
        }

        public UserRegistrationRequest Request { get; private set; }
        public UserManager<UserEntity> UserManager { get; private set; }
        public RoleManager<RoleEntity> RoleManager { get; private set; }


        public override async Task<UserRegistrationResponse> ProcessAsync()
        {
            this.Result.StatusCode = (int)StatusCodes.RegistrationSuccess;

            var registerUser = new CreateUser(this);
            registerUser.SetNext(new AddRoleToUser(this));

            await registerUser.ProcessAsync();

            return this.Result;
        }
    }
}
