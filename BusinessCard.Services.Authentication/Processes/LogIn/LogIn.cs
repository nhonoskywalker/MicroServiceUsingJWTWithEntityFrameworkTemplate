namespace BusinessCard.Services.Authentication.Processes.LogIn
{
    using BusinessCard.Insfrastructure.Messages.LogIn;
    using BusinessCard.Insfrastructure.Processes;
    using BusinessCard.Services.Authentication.Processes.Enums;
    using System.Threading.Tasks;

    public class LogIn : ProcessStep<LogInResponse>
    {
        private readonly LogInContext logInContext;

        public LogIn(LogInContext logInContext)
        {
            this.logInContext = logInContext;
        }


        public override async Task ProcessAsync()
        {
            var request = logInContext.Request;
            var signInResult = await logInContext.SignInManager.PasswordSignInAsync(request.Username, request.Password, false, false);


            if (signInResult.Succeeded)
            {
                if (this.Next != null)
                    await this.Next.ProcessAsync();
            }
            else
            {
                logInContext.Result.SetError((int)StatusCodes.LogInFailed);
            }
        }

    }
}
