using Newtonsoft.Json;

namespace Chinchilla.ClickUp.Responses.ResponseModel
{
    /// <summary>
    /// Model object of a list view
    /// </summary>
    public class ResponseModelListView
        : Helpers.IResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
