namespace BusinessCard.Messages.Users
{
    using DtiTriviaGame.Messages;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class UserRegistrationWebRequest : WebRequest
    {
        [JsonProperty("username")]
        [Required, MinLength(5)]
        public string UserName { get; set; }

        [JsonProperty("password")]
        [Required, MinLength(8)]
        public string Password { get; set; }

        [JsonProperty("email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
