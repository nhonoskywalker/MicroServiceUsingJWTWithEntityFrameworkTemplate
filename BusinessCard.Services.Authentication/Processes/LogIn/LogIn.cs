namespace BusinessCard.Services.Authentication.Processes.LogIn
{
    using BusinessCard.Insfrastructure.Messages.LogIn;
    using BusinessCard.Insfrastructure.Processes;
    using System.Threading.Tasks;

    public class LogIn: IProcessStep<LogInResponse>
    {
        private readonly LogInContext logInContext;

        public LogIn(LogInContext logInContext)
        {
            this.logInContext = logInContext;
        }

        public IProcessStep<LogInResponse> Next { get; set; }

        public async Task ProcessAsync()
        {
            var request = logInContext.Request;
            var signInResult = await logInContext.SignInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
                
           
            if (signInResult.Succeeded)
            {
                await this.Next?.ProcessAsync();
            }
            else
            {
               //set response error
            }
        }

        public void SetNext(IProcessStep<LogInResponse> step)
        {
            if(this.Next == null)
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
