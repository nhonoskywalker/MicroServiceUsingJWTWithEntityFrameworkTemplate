namespace BusinessCard.Insfrastructure.Messages.LogIn
{
    using BusinessCard.Infrastructure.Messages;
    using System.Runtime.Serialization;

    [DataContract]
    public class LogInResponse : Response
    {
        [DataMember]
        public string Data { get; set; }
    }
}
