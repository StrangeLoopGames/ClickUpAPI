using Newtonsoft.Json;
using PaironsTech.ApiHelper.Interfaces;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response object of the method GetAuthorizedTeams()
    /// </summary>
    public class ResponseAuthorizedTeams : IResponse
    {

        /// <summary>
        /// List of Team Model with information of authorized Teams
        /// </summary>
        [JsonProperty("teams")]
        public List<ResponseModelTeam> Teams { get; set; }

    }

}
