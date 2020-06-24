namespace BusinessCard.Services.Users.Processes.UserRegistration
{
    using BusinessCard.Data.Entities.Users;
    using BusinessCard.Insfrastructure.Messages.UserRegistration;
    using BusinessCard.Insfrastructure.Processes;
    using BusinessCard.Services.Users.Enums;
    using System;
    using System.Threading.Tasks;

    public class CreateUser : ProcessStep<UserRegistrationResponse>
    {
        private readonly UserRegistrationContext userRegistrationContext;

        public CreateUser(UserRegistrationContext userRegistrationContext)
        {
            this.userRegistrationContext = userRegistrationContext;
        }

        public override async Task ProcessAsync()
        {
            var request = userRegistrationContext.Request;
            var user = await userRegistrationContext.UserManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                var entity = new UserEntity {
                    UserName = request.Username,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };

                var identityResult = await userRegistrationContext.UserManager.CreateAsync(entity, request.Password);

                if (identityResult.Succeeded)
                {
                    await this.Next?.ProcessAsync();
                }
                else
                {
                    userRegistrationContext.Result.SetError((int)StatusCodes.RegistrationFailed);
                }
            }
            else
            {
                userRegistrationContext.Result.SetError((int)StatusCodes.UserAlreadyExists);
            }
        }

    }
}
