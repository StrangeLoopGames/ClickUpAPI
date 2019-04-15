using PaironsTech.ApiHelper.Attributes;
using PaironsTech.ApiHelper.Interfaces;
using System;

namespace PaironsTech.ClickUpAPI.V1.Params
{

    /// <summary>
    /// The param object of Access Token Request
    /// </summary>
    public class ParamsAccessToken : IParams
    {

        #region Attributes

        /// <summary>
        /// The Client Id
        /// </summary>
        [ParamProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// The Client Secret
        /// </summary>
        [ParamProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// The Code 
        /// </summary>
        [ParamProperty("code")]
        public string Code { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// Method that validate data insert
        /// </summary>
        public void ValidateData()
        {
            if (!string.IsNullOrEmpty(ClientId))
            {
                throw new ArgumentNullException("ClientId");
            }

            if (!string.IsNullOrEmpty(ClientSecret))
            {
                throw new ArgumentNullException("ClientSecret");
            }

            if (!string.IsNullOrEmpty(Code))
            {
                throw new ArgumentNullException("Code");
            }
        }

        #endregion

    }

}
