using Chinchilla.ClickUp.Responses.ResponseModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Chinchilla.ClickUp.Responses
{
    /// <summary>
    /// Model object of list views response
    /// </summary>
    public class ResponseModelListViews 
        : Helpers.IResponse
    {
        [JsonProperty("views")]
        public List<ResponseModelListView> Views { get; set; }

        [JsonProperty("required_views")]
        public Dictionary<string, ResponseModelListView> RequiredViews { get; set; }

        [JsonProperty("default_view")]
        ResponseModelListView Defaultview { get; set; }
    }
}
