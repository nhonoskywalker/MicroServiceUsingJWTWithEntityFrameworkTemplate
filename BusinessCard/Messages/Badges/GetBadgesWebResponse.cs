namespace BusinessCard.Messages.Badges
{
    using BusinessCard.Insfrastructure.Models.Badges;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class GetBadgesWebResponse : WebResponse
    {
        [DataMember]
        [JsonProperty("data")]
        public IEnumerable<BadgeModel> Data { get; set; }
    }
}
