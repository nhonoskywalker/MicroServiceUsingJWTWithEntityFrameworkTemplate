namespace BusinessCard.Insfrastructure.Messages.LogIn
{
    using BusinessCard.Infrastructure.Messages;
    using System.Runtime.Serialization;

    [DataContract]
    public class LogInRequest : Request
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

    }
}
