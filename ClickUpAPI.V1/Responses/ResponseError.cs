using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response received if there is an error in the Request
    /// </summary>
    public abstract class ResponseError : IResponse
    {

        /// <summary>
        /// Message of the Error
        /// </summary>
        [JsonProperty("err")]
        public string Err { get; set; }

        /// <summary>
        /// Status of Http Request
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// Code of the Error
        /// </summary>
        [JsonProperty("ECODE")]
        public string ECode { get; set; }
    }

}
