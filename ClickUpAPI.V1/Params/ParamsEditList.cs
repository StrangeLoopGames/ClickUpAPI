using PaironsTech.ApiHelper.Attributes;
using PaironsTech.ApiHelper.Interfaces;
using System;

namespace PaironsTech.ClickUpAPI.V1.Params
{

    /// <summary>
    /// The Param object of edit list request
    /// </summary>
    public class ParamsEditList : IParams
    {

        #region Attributes

        /// <summary>
        /// The List Id 
        /// </summary>
        [ParamProperty("list_id")]
        public string ListId { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// Method that validate the data insert
        /// </summary>
        public void ValidateData()
        {
            if (string.IsNullOrEmpty(ListId))
            {
                throw new ArgumentNullException("ListId");
            }
        }

        #endregion

    }

}
