using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;
using PaironsTech.ClickUpAPI.V1.Responses.Model;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response object of the method GetAuthorizedUser()
    /// </summary>
    public class ResponseAuthorizedUser : IResponse
    {

        /// <summary>
        /// User Model Object with information of authorized User
        /// </summary>
        [JsonProperty("user")]
        public ModelUser User { get; set; }

    }

}
