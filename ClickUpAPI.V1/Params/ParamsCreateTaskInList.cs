using PaironsTech.ApiHelper.Attributes;
using PaironsTech.ApiHelper.Interfaces;
using System;

namespace PaironsTech.ClickUpAPI.V1.Params
{

    /// <summary>
    /// The param object of CReate Task in List Request
    /// </summary>
    public class ParamsCreateTaskInList : IParams
    {

        #region Attributes

        /// <summary>
        /// The List Id
        /// </summary>
        [ParamProperty("list_id")]
        public string ListId { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// The Constructor of 'ParamsCreateTaskInList'
        /// </summary>
        /// <param name="listId"></param>
        public ParamsCreateTaskInList(string listId)
        {
            ListId = listId;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Method that validate data insert
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
