using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Custom Field information response
    /// </summary>
    public class ResponseModelCustomFields : IResponseModel
    {

        /// <summary>
        /// Check if the Custom Fields are enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

    }
}
