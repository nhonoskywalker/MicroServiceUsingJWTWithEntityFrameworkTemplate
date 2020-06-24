namespace BusinessCard.Extensions.Messages
{
    using BusinessCard.Insfrastructure.Messages.LogIn;
    using BusinessCard.Messages.Authentication;

    public static class AuthenticationExtensions
    {
        public static LogInRequest AsRequest(this LogInWebRequest webRequest)
        {
            var result = new LogInRequest
            {
                Username = webRequest.Username,
                Password = webRequest.Password
            };

            return result;
        }

        public static LogInWebResponse AsWebResponse(this LogInResponse response)
        {
            var result = new LogInWebResponse
            {
                Errors = response.Errors,
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                StatusCode = response.StatusCode,
                Data = response.Data
            };

            return result;
        }
    }
}
