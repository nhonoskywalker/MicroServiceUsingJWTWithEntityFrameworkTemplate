namespace BusinessCard.Insfrastructure.Messages.UserRegistration
{
    using BusinessCard.Infrastructure.Messages;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserRegistrationRequest : Request
    {
        [DataMember]
        public string Username;

        [DataMember]
        public string Email;

        [DataMember]
        public string Password;

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

    }
}
