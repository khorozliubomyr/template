using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class LenderType_PutStateRule_Request
    { 
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
        [JsonProperty("bureau", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Bureau { get; set; }
        [JsonProperty("zips", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Zips { get; set; }
        [JsonProperty("daysToFirstPayment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DaysToFirstPayment { get; set; }
        [JsonProperty("loanAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int LoanAmount { get; set; }
        [JsonProperty("loanAmountOperator", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LoanAmountOperator { get; set; }
        [JsonProperty("apr", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Apr { get; set; }
        [JsonProperty("aprOperator", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AprOperator { get; set; }
        [JsonProperty("rate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Rate { get; set; }
        [JsonProperty("rateOperator", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RateOperator { get; set; }
    }
}
