using PaironsTech.ApiHelper.Attributes;
using PaironsTech.ApiHelper.Interfaces;
using System;

namespace PaironsTech.ClickUpAPI.V1.Params
{

    /// <summary>
    /// The param object of Get Team By ID requet
    /// </summary>
    public class ParamsGetTeamByID : IParams
    {

        #region Attributes

        /// <summary>
        /// The Team Id to search
        /// </summary>
        [ParamProperty("team_id")]
        public string TeamId { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// Method that validate data insert
        /// </summary>
        public void ValidateData()
        {
            if (string.IsNullOrEmpty(TeamId))
            {
                throw new ArgumentNullException("TeamId");
            }
        }

        #endregion

    }

}
