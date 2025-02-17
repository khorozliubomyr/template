using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class LenderType_GetLenderRequirements_Response
    { 
        [JsonProperty("requirements", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Requirements { get; set; }
    }
}
