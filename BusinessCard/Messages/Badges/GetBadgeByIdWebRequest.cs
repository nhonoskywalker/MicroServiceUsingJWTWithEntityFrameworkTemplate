namespace BusinessCard.Messages.Badges
{
    using Newtonsoft.Json;
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class GetBadgeByIdWebRequest
    {
        [DataMember]
        [JsonRequired]
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
