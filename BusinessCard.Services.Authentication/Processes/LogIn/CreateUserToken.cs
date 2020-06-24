namespace BusinessCard.Services.Authentication.Processes.LogIn
{
    using BusinessCard.Insfrastructure.Messages.LogIn;
    using BusinessCard.Insfrastructure.Processes;
    using System;
    using System.Threading.Tasks;

    class CreateUserToken : ProcessStep<LogInResponse>
    {
        private readonly LogInContext logInContext;

        public CreateUserToken(LogInContext logInContext)
        {
            this.logInContext = logInContext;
        }

        public override async Task ProcessAsync()
        {
            var result = logInContext.Result;
            var request = logInContext.Request;
            var tokenService = logInContext.TokenService;
            var userManager = logInContext.UserManager;

            var user = await userManager.FindByNameAsync(request.Username);
            var roles = await userManager.GetRolesAsync(user);

            var token = tokenService.GenerateToken(user, roles);

            if (this.Next != null)
                await this.Next.ProcessAsync();

            result.Data = token;
        }

    }
}
