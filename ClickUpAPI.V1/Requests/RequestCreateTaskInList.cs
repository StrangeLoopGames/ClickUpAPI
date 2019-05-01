using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;
using PaironsTech.ApiHelper.JsonConverters;
using PaironsTech.ClickUpAPI.V1.Enums;
using System;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Requests
{

    /// <summary>
    /// Request object for method CreateTaskInList()
    /// </summary>
    public class RequestCreateTaskInList : IRequest
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
        /// List of user id that will be added to this task
        /// </summary>
        [JsonProperty("assignees")]
        public List<long> Assignees { get; set; }

        /// <summary>
        /// Status of the task
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Prioriry of the task
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
        /// Constructor of RequestCreateTaskInList
        /// </summary>
        /// <param name="name"></param>
        public RequestCreateTaskInList(string name)
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
