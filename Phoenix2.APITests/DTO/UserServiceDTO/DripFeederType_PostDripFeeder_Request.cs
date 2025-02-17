using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.UserServiceDTO
{
    public class DripFeederType_PostDripFeeder_Request
    { 
        [JsonProperty("rank", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Rank { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("sources", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Source_PostDripFeeder_Request> Sources { get; set; }
        [JsonProperty("roleId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RoleId { get; set; }
        [JsonProperty("maxPulls", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxPulls { get; set; }
        [JsonProperty("minutesBetweenPulls", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinutesBetweenPulls { get; set; }
        [JsonProperty("pullNewestFirst", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool PullNewestFirst { get; set; }
        [JsonProperty("useSourceWithLowestCountFirst", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool UseSourceWithLowestCountFirst { get; set; }
        [JsonProperty("isFronterSet", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsFronterSet { get; set; }
    }

    public class Source_PostDripFeeder_Request
    {
        [JsonProperty("sourceId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceId { get; set; }
        [JsonProperty("order", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Order { get; set; }
        [JsonProperty("maxPulls", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxPulls { get; set; }
        [JsonProperty("isRankedSource", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsRankedSource { get; set; }
    }
}
