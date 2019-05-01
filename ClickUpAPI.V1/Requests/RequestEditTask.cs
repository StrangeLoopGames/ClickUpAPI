using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;
using PaironsTech.ApiHelper.JsonConverters;
using PaironsTech.ClickUpAPI.V1.Enums;
using PaironsTech.ClickUpAPI.V1.Requests.Model;
using System;

namespace PaironsTech.ClickUpAPI.V1.Requests
{

    /// <summary>
    /// Request object for method EditTask()
    /// </summary>
    public class RequestEditTask : IRequest
    {

        #region Attributes

        /// <summary>
        /// Name of the task
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Content of the task
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
        
        /// <summary>
        /// List of users id added or removed to the task
        /// </summary>
        [JsonProperty("assignees")]
        public RequestModelSupportAssignees Assignees { get; set; }

        /// <summary>
        /// Status of the Task
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Priority of the Task
        /// </summary>
        [JsonProperty("priority")]
        public TaskPriority? Priority { get; set; }

        /// <summary>
        /// Due Date of the task
        /// </summary>
        [JsonProperty("due_date")]
        [JsonConverter(typeof(JsonConverterDateTimeMilliseconds))]
        public DateTime? DueDate { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor of RequestEditTask
        /// </summary>
        /// <param name="name"></param>
        public RequestEditTask(string name)
        {
            Name = name;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Validation method of data
        /// </summary>
        public void ValidateData()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException("Name");
            }
        }

        #endregion

    }

}
