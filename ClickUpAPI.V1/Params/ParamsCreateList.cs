using PaironsTech.ApiHelper.Attributes;
using PaironsTech.ApiHelper.Interfaces;
using System;

namespace PaironsTech.ClickUpAPI.V1.Params
{

    /// <summary>
    /// The Param object of create list request
    /// </summary>
    public class ParamsCreateList : IParams
    {

        #region Attributes 

        /// <summary>
        /// The Project Id
        /// </summary>
        [ParamProperty("project_id")]
        public string ProjectId { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// The constructor of ParamsCreateList
        /// </summary>
        /// <param name="projectId"></param>
        public ParamsCreateList(string projectId)
        {
            ProjectId = projectId;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Methot that validate the data insert
        /// </summary>
        public void ValidateData()
        {
            if (string.IsNullOrEmpty(ProjectId))
            {
                throw new ArgumentNullException("ProjectId");
            }
        }

        #endregion

    }

}
