using PaironsTech.ApiHelper;
using PaironsTech.ClickUpAPI.V1.OptionalParams;
using PaironsTech.ClickUpAPI.V1.Params;
using PaironsTech.ClickUpAPI.V1.Requests;
using PaironsTech.ClickUpAPI.V1.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaironsTech.ClickUpAPI.V1
{

    /// <summary>
    /// Object that interact through methods the API (v1) of ClickUp
    /// </summary>
    public class ClickUpAPI
    {

        #region Private Attributes

        /// <summary>
        /// Base Address of API call
        /// </summary>
        private static readonly Uri _baseAddress = new Uri("https://api.clickup.com/api/v1/");

        /// <summary>
        /// The Access Token to add during the request
        /// </summary>
        private string _accessToken { get; set; }

        #endregion


        #region Constructors

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
        /// <param name="paramAccessToken">param access token object</param>
        public ClickUpAPI(ParamAccessToken paramAccessToken)
        {
            // Address Uri
            Uri addressUri = new Uri("oauth/token?client_id={client_id}&client_secret={client_secret}&code={code}");

            // Execute Call
            ResponseGeneric<ResponseAccessToken, ResponseError> response = HttpRequest.ExecutePostCall<ResponseAccessToken, ResponseError>(_baseAddress, addressUri, paramsData: paramAccessToken);

            // Manage Response
            if (response.ResponseSuccess != null)
            {
                _accessToken = response.ResponseSuccess.AccessToken;
            }
        }

        #endregion


        #region API Methods

        /// <summary>
        /// Get the user that belongs to this token
        /// </summary>
        /// <returns>ResponseGeneric with ResponseAuthorizedUser response object</returns>
        public ResponseGeneric<ResponseAuthorizedUser, ResponseError> GetAuthorizedUser()
        {
            // Address Uri
            Uri addressUri = new Uri("user");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCall<ResponseAuthorizedUser, ResponseError>(_baseAddress, addressUri, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Get the authorized teams for this token
        /// </summary>
        /// <returns>ResponseGeneric with ResponseAuthorizedTeams response object</returns>
        public ResponseGeneric<ResponseAuthorizedTeams, ResponseError> GetAuthorizedTeams()
        {
            // Address Uri
            Uri addressUri = new Uri("team");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCall<ResponseAuthorizedTeams, ResponseError>(_baseAddress, addressUri, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Get a team's details. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="paramGetTeamByID">param get team by ID</param>
        /// <returns>ResponseGeneric with ResponseTeam response object</returns>
        public ResponseGeneric<ResponseTeam, ResponseError> GetTeamByID(ParamGetTeamByID paramGetTeamByID)
        {
            // Address Uri
            Uri addressUri = new Uri("team/{team_id}");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCall<ResponseTeam, ResponseError>(_baseAddress, addressUri, paramsData: paramGetTeamByID, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Get a team's spaces. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns>ResponseGeneric with ResponseTeamSpace response object</returns>
        public ResponseGeneric<ResponseTeamSpace, ResponseError> GetTeamSpace(string teamId)
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
        public ResponseGeneric<ResponseSpaceProjects, ResponseError> GetSpaceProjects(string spaceId)
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
        public ResponseGeneric<ModelList, ResponseError> CreateList(string projectId, RequestCreateList requestData)
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
        public ResponseGeneric<ModelList, ResponseError> EditList(string listId, RequestEditList requestData)
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
        public ResponseGeneric<ResponseTasks, ResponseError> GetTasks(string teamId, OPGetTasks optionalParams)
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
        public ResponseGeneric<ModelTask, ResponseError> CreateTaskInList(string listId, RequestCreateTaskInList requestData)
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
        public ResponseGeneric<ResponseSuccess, ResponseError> EditTask(string taskId, RequestEditTask requestData)
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
        public Task<ResponseGeneric<ResponseAuthorizedUser, ResponseError>> GetAuthorizedUserAsync()
        {
            // Address Uri
            Uri addressUri = new Uri("user");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCallAsync<ResponseAuthorizedUser, ResponseError>(_baseAddress, addressUri, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Get the authorized teams for this token
        /// </summary>
        /// <returns>ResponseGeneric with ResponseAuthorizedTeams expected</returns>
        public Task<ResponseGeneric<ResponseAuthorizedTeams, ResponseError>> GetAuthorizedTeamsAsync()
        {
            // Address Uri
            Uri addressUri = new Uri("team");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCallAsync<ResponseAuthorizedTeams, ResponseError>(_baseAddress, addressUri, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Get a team's details. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="paramGetTeamByID">param get team by ID</param>
        /// <returns>ResponseGeneric with ResponseTeam response object</returns>
        public Task<ResponseGeneric<ResponseTeam, ResponseError>> GetTeamByIDAsync(ParamGetTeamByID paramGetTeamByID)
        {
            // Address Uri
            Uri addressUri = new Uri("team/{team_id}");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCallAsync<ResponseTeam, ResponseError>(_baseAddress, addressUri, paramsData: paramGetTeamByID, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Get a team's spaces. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns>ResponseGeneric with ResponseTeamSpace object expected</returns>
        public Task<ResponseGeneric<ResponseTeamSpace, ResponseError>> GetTeamSpacesAsync(string teamId)
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
        public Task<ResponseGeneric<ResponseSpaceProjects, ResponseError>> GetSpaceProjectsAsync(string spaceId)
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
        public Task<ResponseGeneric<ModelList, ResponseError>> CreateListAsync(string projectId, RequestCreateList requestData)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("projectId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "project/" + projectId + "/list";
            return ExecutePostCallAsync<ModelList, ResponseError>(requestUri, requestData);
        }

        /// <summary>
        /// Edit List informations
        /// </summary>
        /// <param name="listId">listId</param>
        /// <param name="requestData">RequestEditList object</param>
        /// <returns>ResponseGeneric with ModelList object expected</returns>
        public Task<ResponseGeneric<ModelList, ResponseError>> EditListAsync(string listId, RequestEditList requestData)
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
        public Task<ResponseGeneric<ResponseTasks, ResponseError>> GetTasksAsync(string teamId, OPGetTasks optionalParams)    
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
        public Task<ResponseGeneric<ModelTask, ResponseError>> CreateTaskInListAsync(string listId, RequestCreateTaskInList requestData)
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
        public Task<ResponseGeneric<ResponseSuccess, ResponseError>> EditTaskAsync(string taskId, RequestEditTask requestData)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("taskId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");
            string requestUri = "task/" + taskId;
            return ExecutePutCallAsync<ResponseSuccess>(requestUri, requestData);
        }


        #endregion

    }

}
