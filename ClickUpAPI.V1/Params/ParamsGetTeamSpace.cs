using PaironsTech.ApiHelper.Attributes;
using PaironsTech.ApiHelper.Interfaces;
using System;

namespace PaironsTech.ClickUpAPI.V1.Params
{

    /// <summary>
    /// The param object of get team space request
    /// </summary>
    public class ParamsGetTeamSpace : IParams
    {

        #region Attributes

        /// <summary>
        /// The Team Id
        /// </summary>
        [ParamProperty("team_id")]
        public string TeamId { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// The constructor of ParamsGetTeamSpace
        /// </summary>
        /// <param name="teamId"></param>
        public ParamsGetTeamSpace(string teamId)
        {
            TeamId = teamId;
        }

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
