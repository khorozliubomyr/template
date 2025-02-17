using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ContactServiceDTO
{
    public class NegativeScenario_ContatService
    {
        [JsonProperty("errorType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorType { get; set; }
        [JsonProperty("errorMessage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
    }
}
