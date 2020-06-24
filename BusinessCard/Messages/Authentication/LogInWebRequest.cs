namespace BusinessCard.Messages.Authentication
{
    using Newtonsoft.Json;
    using System.Runtime.Serialization;

    [DataContract]
    public class LogInWebRequest
    {
        [DataMember]
        [JsonProperty("username")]
        [JsonRequired]
        public string Username { get; set; }

        [DataMember]
        [JsonProperty("password")]
        [JsonRequired]
        public string Password { get; set; }
    }
}
