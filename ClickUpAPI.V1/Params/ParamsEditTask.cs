using PaironsTech.ApiHelper.Attributes;
using PaironsTech.ApiHelper.Interfaces;
using System;

namespace PaironsTech.ClickUpAPI.V1.Params
{

    /// <summary>
    /// The param object of Edit Task Request
    /// </summary>
    public class ParamsEditTask : IParams
    {

        #region Attributes

        /// <summary>
        /// The Task Id
        /// </summary>
        [ParamProperty("task_id")]
        public string TaskId { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// Method that validate data insert
        /// </summary>
        public void ValidateData()
        {
            if (string.IsNullOrEmpty(TaskId))
            {
                throw new ArgumentNullException("TaskId");
            }
        }

        #endregion

    }

}
