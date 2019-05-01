using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Multiple Assignees information response
    /// </summary>
    public class ResponseModelMultipleAssignees : IResponseModel
    {

        /// <summary>
        /// Check if the Multiple Assignees are enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

    }

}
