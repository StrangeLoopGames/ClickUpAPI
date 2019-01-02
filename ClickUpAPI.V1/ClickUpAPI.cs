using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.OptionalParams;
using PaironsTech.ClickUpAPI.V1.Requests;
using PaironsTech.ClickUpAPI.V1.Responses;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaironsTech.ClickUpAPI.V1
{
    public class ClickUpAPI
    {
        
        // Private Static Attributes 
        private static readonly Uri _baseAddress = new Uri("https://api.clickup.com/api/v1/");


        // Private Attributes
        private string _accessToken { get; set; }


        // Constructors

        /// <summary>
        /// Create object with Personal Access Token
        /// </summary>
        /// <param name="accessToken">Personal Access Token</param>
        public ClickUpAPI(string accessToken)
        {
            _accessToken = accessToken;
        }

        /// <summary>
        /// Create Object with ClientId, ClientSecrect
        /// </summary>
        /// <param name="clientId">own clientId</param>
        /// <param name="clientSecret">own clientSecret</param>
        public ClickUpAPI(string clientId, string clientSecret, string code)
        {
            string requestUri = "oauth/token?client_id=" + clientId + "&client_secret=" + clientSecret + "&code=" + code;

            // Execute Async call, wait response, get access Token and set in private attribute
            Task.Run(async () =>
            {
                ResponseGeneric<ResponseAccessToken> response = await ExecutePostCallAsync<ResponseAccessToken>(requestUri, null);

                if (response.ResponseSuccess != null)
                    _accessToken = response.ResponseSuccess.AccessToken;

            }).Wait();
        }



        #region API Methods


        /// <summary>
        /// Get the user that belongs to this token
        /// </summary>
        /// <returns>ResponseGeneric with ResponseAuthorizedUser response object</returns>
        public ResponseGeneric<ResponseAuthorizedUser> GetAuthorizedUser()
        {
            string requestUri = "user";

            ResponseGeneric<ResponseAuthorizedUser> responseGeneric = new ResponseGeneric<ResponseAuthorizedUser>();

            Task.Run(async () =>
            {
                responseGeneric = await ExecuteGetCallAsync<ResponseAuthorizedUser>(requestUri);
            })
            .Wait();
            
            return responseGeneric;
        }

        /// <summary>
        /// Get the authorized teams for this token
        /// </summary>
        /// <returns>ResponseGeneric with ResponseAuthorizedTeams response object</returns>
        public ResponseGeneric<ResponseAuthorizedTeams> GetAuthorizedTeams()
        {
            string requestUri = "team";

            ResponseGeneric<ResponseAuthorizedTeams> responseGeneric = new ResponseGeneric<ResponseAuthorizedTeams>();

            Task.Run(async () =>
            {
                responseGeneric = await ExecuteGetCallAsync<ResponseAuthorizedTeams>(requestUri);
            })
            .Wait();
            
            return responseGeneric;
        }

        /// <summary>
        /// Get a team's details. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns>ResponseGeneric with ResponseTeam response object</returns>
        public ResponseGeneric<ResponseTeam> GetTeamByID(string teamId)
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string requestUri = "team/" + teamId;

            ResponseGeneric<ResponseTeam> responseGeneric = new ResponseGeneric<ResponseTeam>();

            Task.Run(async () =>
            {
                responseGeneric = await ExecuteGetCallAsync<ResponseTeam>(requestUri);
            })
            .Wait();

            return responseGeneric;
        }

        /// <summary>
        /// Get a team's spaces. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns>ResponseGeneric with ResponseTeamSpace response object</returns>
        public ResponseGeneric<ResponseTeamSpace> GetTeamSpace(string teamId)
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string requestUri = "team/" + teamId + "/space";

            ResponseGeneric<ResponseTeamSpace> responseGeneric = new ResponseGeneric<ResponseTeamSpace>();

            Task.Run(async () =>
            {
                responseGeneric = await ExecuteGetCallAsync<ResponseTeamSpace>(requestUri);
            })
            .Wait();

            return responseGeneric;
        }

        /// <summary>
        /// Get a space's projects. The projects' lists will also be included.
        /// </summary>
        /// <param name="spaceId">spaceId</param>
        /// <returns>ResponseGeneric with ResponseSpaceProjects response object</returns>
        public ResponseGeneric<ResponseSpaceProjects> GetSpaceProjects(string spaceId)
        {
            if (string.IsNullOrEmpty(spaceId)) throw new ArgumentException("spaceId can't be empty or null!");

            string requestUri = "space/" + spaceId + "/project";

            ResponseGeneric<ResponseSpaceProjects> responseGeneric = new ResponseGeneric<ResponseSpaceProjects>();

            Task.Run(async () =>
            {
                responseGeneric = await ExecuteGetCallAsync<ResponseSpaceProjects>(requestUri);
            })
            .Wait();

            return responseGeneric;
        }

        /// <summary>
        /// Create List in Project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="requestData">RequestCreateList object</param>
        /// <returns>ResponseGeneric with ModelList response object</returns>
        public ResponseGeneric<ModelList> CreateList(string projectId, RequestCreateList requestData)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("projectId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "project/" + projectId + "/list";

            ResponseGeneric<ModelList> responseGeneric = new ResponseGeneric<ModelList>();

            Task.Run(async () =>
            {
                responseGeneric = await ExecutePostCallAsync<ModelList>(requestUri, requestData);
            })
            .Wait();

            return responseGeneric;
        }

        /// <summary>
        /// Edit List informations
        /// </summary>
        /// <param name="listId">listId</param>
        /// <param name="requestData">RequestEditList object</param>
        /// <returns>ResponseGeneric with ModelList response object</returns>
        public ResponseGeneric<ModelList> EditList(string listId, RequestEditList requestData)
        {
            if (string.IsNullOrEmpty(listId)) throw new ArgumentException("listId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "list/" + listId;

            ResponseGeneric<ModelList> responseGeneric = new ResponseGeneric<ModelList>();
            
            Task.Run(async () =>
            {
                responseGeneric = await ExecutePutCallAsync<ModelList>(requestUri, requestData);
            })
            .Wait();

            return responseGeneric;
        }

        /// <summary>
        /// Get Tasks of the Team and filter its by optionalParams
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <param name="optionalParams">OptionalParamsGetTask object</param>
        /// <returns>ResponseGeneric with ResponseTasks response object</returns>
        public ResponseGeneric<ResponseTasks> GetTasks(string teamId, OPGetTasks optionalParams)
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string strParams = GenerateOptionalParams(optionalParams);
            string requestUri = "team/" + teamId + "/task" + (!string.IsNullOrEmpty(strParams) ? "?" + strParams : string.Empty);

            ResponseGeneric<ResponseTasks> responseGeneric = new ResponseGeneric<ResponseTasks>();

            Task.Run(async () =>
            {
                responseGeneric = await ExecuteGetCallAsync<ResponseTasks>(requestUri);
            })
            .Wait();

            return responseGeneric;
        }

        /// <summary>
        /// Create Task in List.
        /// </summary>
        /// <param name="listId">listId</param>
        /// <param name="requestData">RequestCreateTaskInList object</param>
        /// <returns>ResponseGeneric with ModelTask object Expected</returns>
        public ResponseGeneric<ModelTask> CreateTaskInList(string listId, RequestCreateTaskInList requestData)
        {
            if (string.IsNullOrEmpty(listId)) throw new ArgumentException("listId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "list/" + listId + "/task";

            ResponseGeneric<ModelTask> responseGeneric = new ResponseGeneric<ModelTask>();

            Task.Run(async () =>
            {
                responseGeneric = await ExecutePostCallAsync<ModelTask>(requestUri, requestData);
            })
            .Wait();

            return responseGeneric;
        }

        /// <summary>
        /// Edit Task informations.
        /// </summary>
        /// <param name="taskId">taskId</param>
        /// <param name="requestData">RequestEditTask object</param>
        /// <returns>ResponseGeneric with ResponseSuccess response object</returns>
        public ResponseGeneric<ResponseSuccess> EditTask(string taskId, RequestEditTask requestData)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("taskId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "task/" + taskId;

            ResponseGeneric<ResponseSuccess> responseGeneric = new ResponseGeneric<ResponseSuccess>();

            Task.Run(async () =>
            {
                responseGeneric = await ExecutePutCallAsync<ResponseSuccess>(requestUri, requestData);
            })
            .Wait();

            return responseGeneric;
        }


        #endregion


        #region API Methods Async


        /// <summary>
        /// Get the user that belongs to this token
        /// </summary>
        /// <returns>ResponseGeneric with ResponseAuthorizedUser object expected</returns>
        public Task<ResponseGeneric<ResponseAuthorizedUser>> GetAuthorizedUserAsync()
        {
            string requestUri = "user";
            return ExecuteGetCallAsync<ResponseAuthorizedUser>(requestUri);
        }

        /// <summary>
        /// Get the authorized teams for this token
        /// </summary>
        /// <returns>ResponseGeneric with ResponseAuthorizedTeams expected</returns>
        public Task<ResponseGeneric<ResponseAuthorizedTeams>> GetAuthorizedTeamsAsync()
        {
            string requestUri = "team";
            return ExecuteGetCallAsync<ResponseAuthorizedTeams>(requestUri);
        }

        /// <summary>
        /// Get a team's details. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns>ResponseGeneric with ResponseTeam object expected</returns>
        public Task<ResponseGeneric<ResponseTeam>> GetTeamByIDAsync(string teamId)
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string requestUri = "team/" + teamId;
            return ExecuteGetCallAsync<ResponseTeam>(requestUri);
        }

        /// <summary>
        /// Get a team's spaces. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns>ResponseGeneric with ResponseTeamSpace object expected</returns>
        public Task<ResponseGeneric<ResponseTeamSpace>> GetTeamSpacesAsync(string teamId)
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string requestUri = "team/" + teamId + "/space";
            return ExecuteGetCallAsync<ResponseTeamSpace>(requestUri);
        }

        /// <summary>
        /// Get a space's projects. The projects' lists will also be included.
        /// </summary>
        /// <param name="spaceId">spaceId</param>
        /// <returns>ResponseGeneric with ResponseSpaceProjects object expected</returns>
        public Task<ResponseGeneric<ResponseSpaceProjects>> GetSpaceProjectsAsync(string spaceId)
        {
            if (string.IsNullOrEmpty(spaceId)) throw new ArgumentException("spaceId can't be empty or null!");

            string requestUri = "space/" + spaceId + "/project";
            return ExecuteGetCallAsync<ResponseSpaceProjects>(requestUri);
        }

        /// <summary>
        /// Create List in Project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="requestData">RequestCreateList object</param>
        /// <returns>ResponseGeneric with ModelList object expected</returns>
        public Task<ResponseGeneric<ModelList>> CreateListAsync(string projectId, RequestCreateList requestData)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("projectId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "project/" + projectId + "/list";
            return ExecutePostCallAsync<ModelList>(requestUri, requestData);
        }

        /// <summary>
        /// Edit List informations
        /// </summary>
        /// <param name="listId">listId</param>
        /// <param name="requestData">RequestEditList object</param>
        /// <returns>ResponseGeneric with ModelList object expected</returns>
        public Task<ResponseGeneric<ModelList>> EditListAsync(string listId, RequestEditList requestData)
        {
            if (string.IsNullOrEmpty(listId)) throw new ArgumentException("listId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");
            
            string requestUri = "list/" + listId;
            return ExecutePutCallAsync<ModelList>(requestUri, requestData);
        }

        /// <summary>
        /// Get Tasks of the Team and filter its by optionalParams
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <param name="optionalParams">OptionalParamsGetTask object</param>
        /// <returns>ResponseGeneric with ResponseTasks object expected</returns>
        public Task<ResponseGeneric<ResponseTasks>> GetTasksAsync(string teamId, OPGetTasks optionalParams)    
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string strParams = GenerateOptionalParams(optionalParams);
            string requestUri = "team/" + teamId + "/task" + (!string.IsNullOrEmpty(strParams) ? "?" + strParams : string.Empty);
            return ExecuteGetCallAsync<ResponseTasks>(requestUri);
        }

        /// <summary>
        /// Create Task in List.
        /// </summary>
        /// <param name="listId">listId</param>
        /// <param name="requestData">RequestCreateTaskInList object</param>
        /// <returns>ResponseGeneric with ModelTask object Expected</returns>
        public Task<ResponseGeneric<ModelTask>> CreateTaskInListAsync(string listId, RequestCreateTaskInList requestData)
        {
            if (string.IsNullOrEmpty(listId)) throw new ArgumentException("listId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "list/" + listId + "/task";
            return ExecutePostCallAsync<ModelTask>(requestUri, requestData);
        }

        /// <summary>
        /// Edit Task informations.
        /// </summary>
        /// <param name="taskId">taskId</param>
        /// <param name="requestData">RequestEditTask object</param>
        /// <returns>ResponseGeneric with ResponseSuccess object expected</returns>
        public Task<ResponseGeneric<ResponseSuccess>> EditTaskAsync(string taskId, RequestEditTask requestData)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("taskId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");
            string requestUri = "task/" + taskId;
            return ExecutePutCallAsync<ResponseSuccess>(requestUri, requestData);
        }


        #endregion


        #region Private Methods


        /****************************
         * 
         *  Manage Optional Params
         * 
         ***************************/

        private string GenerateOptionalParams(OptionalParams.OptionalParams optionalParams)
        {
            List<string> listParamKeyValue = new List<string>();
            PropertyInfo[] props = optionalParams.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object value = prop.GetValue(optionalParams);

                if (value != null)
                    listParamKeyValue.Add(SerializePropName(prop) + "=" + SerializePropValue(prop, value));
            }
            
            return string.Join("&", listParamKeyValue);
        }

        private string SerializePropName(PropertyInfo prop)
        {
            List<JsonPropertyAttribute> attrsJsonProperty = prop.GetCustomAttributes<JsonPropertyAttribute>(true).ToList();
            if (attrsJsonProperty.Count > 0) return attrsJsonProperty[0].PropertyName;
            return prop.Name;
        }

        private string SerializePropValue(PropertyInfo prop, object value)
        {
            if (value is DateTime dateTime) return new DateTimeOffset(((DateTime)value)).ToUnixTimeMilliseconds().ToString();
            if (value is TimeSpan timeSpan) return timeSpan.TotalMilliseconds.ToString();

            return value.ToString();
        }



        /*********************************
         * 
         *  Manage Response and Request
         * 
         ********************************/

        private Response ManageResponses<TResponse>(HttpStatusCode httpStatusCode, string responseData) where TResponse : Response
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.OK: return DeserializeResponse<TResponse>(responseData);
                default: return DeserializeResponse<ResponseError>(responseData);
            }
        }

        private TResponse DeserializeResponse<TResponse>(string responseData) where TResponse : Response
        {
            return JsonConvert.DeserializeObject<TResponse>(responseData);
        }

        private async Task<ResponseGeneric<TResponseExpected>> ExecuteGetCallAsync<TResponseExpected>(string requestUri) where TResponseExpected : Response
        {
            ResponseGeneric<TResponseExpected> responseGeneric = new ResponseGeneric<TResponseExpected>();

            using (var httpClient = new HttpClient { BaseAddress = _baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", _accessToken);

                using (var httpResponse = await httpClient.GetAsync(requestUri))
                {
                    string responseData = await httpResponse.Content.ReadAsStringAsync();

                    Response response = ManageResponses<TResponseExpected>(httpResponse.StatusCode, responseData);

                    if (response is TResponseExpected)
                    {
                        responseGeneric.ResponseSuccess = (TResponseExpected)response;
                    }
                    else
                    {
                        responseGeneric.ResponseError = (ResponseError)response;
                    }
                }
            }

            return responseGeneric;
        }

        private async Task<ResponseGeneric<TResponseExpected>> ExecutePostCallAsync<TResponseExpected>(string requestUri, Request request) where TResponseExpected : Response
        {
            ResponseGeneric<TResponseExpected> responseGeneric = new ResponseGeneric<TResponseExpected>();

            using (var httpClient = new HttpClient { BaseAddress = _baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", _accessToken);

                using (var content = request != null ? new StringContent(JsonConvert.SerializeObject(request), Encoding.Default, "application/json") : new StringContent("{}", Encoding.Default, "application/json"))
                {
                    using (var httpResponse = await httpClient.PostAsync(requestUri, content))
                    {
                        string responseData = await httpResponse.Content.ReadAsStringAsync();

                        Response response = ManageResponses<TResponseExpected>(httpResponse.StatusCode, responseData);

                        if (response is TResponseExpected)
                        {
                            responseGeneric.ResponseSuccess = (TResponseExpected)response;
                        }
                        else
                        {
                            responseGeneric.ResponseError = (ResponseError)response;
                        }
                    }
                }
            }

            return responseGeneric;
        }

        private async Task<ResponseGeneric<TResponseExpected>> ExecutePutCallAsync<TResponseExpected>(string requestUri, Request request) where TResponseExpected : Response
        {
            ResponseGeneric<TResponseExpected> responseGeneric = new ResponseGeneric<TResponseExpected>();

            using (var httpClient = new HttpClient { BaseAddress = _baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", _accessToken);

                using (var content = request != null ? new StringContent(JsonConvert.SerializeObject(request), Encoding.Default, "application/json") : new StringContent("{}", Encoding.Default, "application/json"))
                {
                    using (var httpResponse = await httpClient.PutAsync(requestUri, content))
                    {
                        string responseData = await httpResponse.Content.ReadAsStringAsync();

                        Response response = ManageResponses<TResponseExpected>(httpResponse.StatusCode, responseData);

                        if (response is TResponseExpected)
                        {
                            responseGeneric.ResponseSuccess = (TResponseExpected)response;
                        }
                        else
                        {
                            responseGeneric.ResponseError = (ResponseError)response;
                        }
                    }
                }
            }

            return responseGeneric;
        }

        #endregion

    }
}
