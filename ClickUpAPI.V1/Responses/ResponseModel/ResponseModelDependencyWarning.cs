using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Dependency Warning information response
    /// </summary>
    public class ResponseModelDependencyWarning : IResponseModel
    {

        /// <summary>
        /// Check if the Dependecy Warning are enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

    }

}
