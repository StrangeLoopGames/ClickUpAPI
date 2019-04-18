using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;
using System;

namespace PaironsTech.ClickUpAPI.V1.Requests
{

    /// <summary>
    /// Request object for method CreateList()
    /// </summary>
    public class RequestCreateList : IRequest
    {

        #region Attributes

        /// <summary>
        /// Name of the new list
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// The constructor of RequestCreateList
        /// </summary>
        /// <param name="name"></param>
        public RequestCreateList(string name)
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
