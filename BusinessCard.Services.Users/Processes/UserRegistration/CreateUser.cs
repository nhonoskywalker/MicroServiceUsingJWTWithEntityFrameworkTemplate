namespace BusinessCard.Services.Users.Processes.UserRegistration
{
    using BusinessCard.Data.Entities.Users;
    using BusinessCard.Insfrastructure.Messages.UserRegistration;
    using BusinessCard.Insfrastructure.Processes;
    using System;
    using System.Threading.Tasks;

    public class CreateUser : IProcessStep<UserRegistrationResponse>
    {
        private readonly UserRegistrationContext userRegistrationContext;

        public CreateUser(UserRegistrationContext userRegistrationContext)
        {
            this.userRegistrationContext = userRegistrationContext;
        }

        public IProcessStep<UserRegistrationResponse> Next { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task ProcessAsync()
        {
            var request = userRegistrationContext.Request;
            var user = await userRegistrationContext.UserManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                var entity = new UserEntity {
                    UserName = request.Username,
                    Email = request.Email,
                
                };
                var identityResult = await userRegistrationContext.UserManager.CreateAsync(entity, request.Password);

                if (identityResult.Succeeded)
                {
                    await this.Next?.ProcessAsync();
                }
                else
                {
                    //error
                }
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
