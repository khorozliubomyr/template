using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.PaymentServiceDTO
{
    public class DownPaymentType_PostDownpayments_Request
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
        [JsonProperty("contactCreditCardId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactCreditCardId { get; set; }
        [JsonProperty("amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Amount { get; set; }
        [JsonProperty("processingDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ProcessingDate { get; set; }
        [JsonProperty("processedDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ProcessedDate { get; set; }
        [JsonProperty("processedAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ProcessedAmount { get; set; }
        [JsonProperty("notes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; set; }
        [JsonProperty("isCurrent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCurrent { get; set; }
        [JsonProperty("isProcessed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsProcessed { get; set; }
        [JsonProperty("transactionType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionType { get; set; }
        [JsonProperty("transactionStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionStatus { get; set; }
        [JsonProperty("transactionId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionId { get; set; }
        [JsonProperty("transactionTag", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionTag { get; set; }
        [JsonProperty("validationStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ValidationStatus { get; set; }
        [JsonProperty("bankRespCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string BankRespCode { get; set; }
        [JsonProperty("bankMessage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string BankMessage { get; set; }
        [JsonProperty("gatewayRespCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string GatewayRespCode { get; set; }
        [JsonProperty("gatewayMessage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string GatewayMessage { get; set; }
        [JsonProperty("correlationID", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CorrelationID { get; set; }
        [JsonProperty("avsCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AvsCode { get; set; }
        [JsonProperty("cvvCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CvvCode { get; set; }
        [JsonProperty("errors", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Errors { get; set; }
        [JsonProperty("paymentType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentType { get; set; }
        [JsonProperty("isSyncedToAcumatica", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int IsSyncedToAcumatica { get; set; }
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
    }
}
