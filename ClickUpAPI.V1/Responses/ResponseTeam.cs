using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;
using PaironsTech.ClickUpAPI.V1.Responses.Model;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response object of the method GetTeamByID()
    /// </summary>
    public class ResponseTeam : IResponse
    {

        /// <summary>
        /// Team Model object with the information of the team
        /// </summary>
        [JsonProperty("team")]
        public ResponseModelTeam Team { get; set; }

    }

}
