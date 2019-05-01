using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Requests.Model
{

    /// <summary>
    /// Support Models for assigness user at the task
    /// </summary>
    public class RequestModelSupportAssignees : IRequestModel
    {

        #region Attributes

        /// <summary>
        /// List of integer id of the user added to the task
        /// </summary>
        [JsonProperty("add")]
        public List<long> Add { get; set; }


        /// <summary>
        /// List of integer id of the user removed to the task
        /// </summary>
        [JsonProperty("rem")]
        public List<long> Rem { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// Validation method of data
        /// </summary>
        public void ValidateData() { }

        #endregion

    }

}
