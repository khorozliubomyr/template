using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class Condition_PutDocumentTypesDocument_Request
    {
        [JsonProperty("mappedFieldId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MappedFieldId { get; set; }
        [JsonProperty("conditionType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ConditionType { get; set; }
        [JsonProperty("value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
        [JsonProperty("valueType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ValueType { get; set; }
    }

    public class DocusignField_PutDocumentTypesDocument_Request
    {
        [JsonProperty("x", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int X { get; set; }
        [JsonProperty("y", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Y { get; set; }
        [JsonProperty("width", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Width { get; set; }
        [JsonProperty("height", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Height { get; set; }
        [JsonProperty("page", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Page { get; set; }
        [JsonProperty("textValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TextValue { get; set; }
        [JsonProperty("conditions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Condition_PutDocumentTypesDocument_Request> Conditions { get; set; }
    }

    public class Field_PutDocumentTypesDocument_Request
    {
        [JsonProperty("pdfField", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PdfField { get; set; }
        [JsonProperty("mappedFieldId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MappedFieldId { get; set; }
        [JsonProperty("textValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TextValue { get; set; }
        [JsonProperty("conditions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Condition_PutDocumentTypesDocument_Request> Conditions { get; set; }
    }

    public class DocumentType_PutDocumentTypesDocument_Request
    { 
        [JsonProperty("fields", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Field_PutDocumentTypesDocument_Request> Fields { get; set; }
        [JsonProperty("docusignFields", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<DocusignField_PutDocumentTypesDocument_Request> DocusignFields { get; set; }
    }
}
