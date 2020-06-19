namespace BusinessCard.Extensions.Messages
{
    using BusinessCard.Insfrastructure.Messages.UserRegistration;
    using BusinessCard.Messages.Users;

    public static class UserMessagesExtensions
    {
        public static UserRegistrationRequest AsRequest(this UserRegistrationWebRequest request)
        {
            var result = new UserRegistrationRequest
            {
                Username = request.UserName,
                Password = request.Password,
                Email = request.Email
            };

            return result;
        }

        public static UserRegistrationWebResponse AsWebResponse(this UserRegistrationResponse response)
        {
            var result = new UserRegistrationWebResponse
            {
                Errors = response.Errors,
                Message = response.Message,
                StatusCode = response.StatusCode,
                IsSuccessful = response.IsSuccessful
            };

            return result;
        }
    }
}
