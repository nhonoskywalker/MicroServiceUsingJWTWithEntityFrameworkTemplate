namespace BusinessCard.Services.Users.Processes.UserRegistration
{
    using BusinessCard.Insfrastructure.Messages.UserRegistration;
    using BusinessCard.Insfrastructure.Processes;
    using BusinessCard.Services.Users.Enums;
    using System.Threading.Tasks;

    public class AddRoleToUser : ProcessStep<UserRegistrationResponse>
    {
        private readonly UserRegistrationContext userRegistrationContext;

        public AddRoleToUser(UserRegistrationContext userRegistrationContext)
        {
            this.userRegistrationContext = userRegistrationContext;
        }


        public override async Task ProcessAsync()
        {
            var userManager = userRegistrationContext.UserManager;
            var request = userRegistrationContext.Request;
            var user = await userRegistrationContext.UserManager.FindByEmailAsync(request.Email);

            var identityResult = await userManager.AddToRoleAsync(user, "User");

            if (identityResult.Succeeded)
            {
                if (this.Next != null)
                    await this.Next.ProcessAsync();
            }
            else
            {
                userRegistrationContext.Result.SetError((int)StatusCodes.AddRoleFailed);
            }

        }

    }
}
