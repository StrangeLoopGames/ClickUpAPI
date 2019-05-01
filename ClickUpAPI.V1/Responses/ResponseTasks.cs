using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response object of the method GetTasks()
    /// </summary>
    public class ResponseTasks : IResponse
    {

        /// <summary>
        /// List of Model Task with information of Tasks received
        /// </summary>
        [JsonProperty("tasks")]
        public List<ResponseModelTask> Tasks { get; set; }
        
    }

}
