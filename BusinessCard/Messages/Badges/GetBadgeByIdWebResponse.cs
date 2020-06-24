namespace BusinessCard.Messages.Badges
{
    using BusinessCard.Insfrastructure.Models.Badges;
    using Newtonsoft.Json;
    using System.Runtime.Serialization;

    [DataContract]
    public class GetBadgeByIdWebResponse : WebResponse
    {
        [DataMember]
        [JsonProperty("data")]
        public BadgeModel Data { get; set; }
    }
}
