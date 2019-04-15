using PaironsTech.ApiHelper.Attributes;
using PaironsTech.ApiHelper.Interfaces;
using System;

namespace PaironsTech.ClickUpAPI.V1.Params
{

    /// <summary>
    /// The param object of Get Space Projects request
    /// </summary>
    public class ParamsGetSpaceProjects : IParams
    {

        #region Attributes

        /// <summary>
        /// The Space Id 
        /// </summary>
        [ParamProperty("space_id")]
        public string SpaceId { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// Method that validate the data insert
        /// </summary>
        public void ValidateData()
        {
            if (string.IsNullOrEmpty(SpaceId))
            {
                throw new ArgumentNullException("SpaceId");
            }
        }

        #endregion

    }

}
