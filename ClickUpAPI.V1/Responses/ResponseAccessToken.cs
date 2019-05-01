using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response object of the Authentication
    /// </summary>
    public class ResponseAccessToken : IResponse
    {

        /// <summary>
        /// AccessToken Returned
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

    }

}
