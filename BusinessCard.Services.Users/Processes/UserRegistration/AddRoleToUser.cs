namespace BusinessCard.Services.Users.Processes.UserRegistration
{
    using BusinessCard.Insfrastructure.Messages.UserRegistration;
    using BusinessCard.Insfrastructure.Processes;
    using System;
    using System.Threading.Tasks;

    public class AddRoleToUser : IProcessStep<UserRegistrationResponse>
    {
        private readonly UserRegistrationContext userRegistrationContext;

        public AddRoleToUser(UserRegistrationContext userRegistrationContext)
        {
            this.userRegistrationContext = userRegistrationContext;
        }

        public IProcessStep<UserRegistrationResponse> Next { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task ProcessAsync()
        {
            var userManager = userRegistrationContext.UserManager;
            var request = userRegistrationContext.Request;
            var user = await userRegistrationContext.UserManager.FindByEmailAsync(request.Email);

            var identityResult = await userManager.AddToRoleAsync(user, "User");

            if (identityResult.Succeeded)
            {
                await this.Next.ProcessAsync();
            }
            else
            {
               //error
            }

        }

        public void SetNext(IProcessStep<UserRegistrationResponse> step)
        {
            if (this.Next == null)
            {
                this.Next = step;
            }
            else
            {
                this.Next.SetNext(step);
            }
        }
    }
}
