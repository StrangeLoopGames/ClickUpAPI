using PaironsTech.ApiHelper;
using PaironsTech.ClickUpAPI.V1.Params;
using PaironsTech.ClickUpAPI.V1.Requests;
using PaironsTech.ClickUpAPI.V1.Responses;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
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
        public ClickUpAPI(ParamsAccessToken paramAccessToken)
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
            Uri addressUri = new Uri("/user");

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
        /// <param name="paramsGetTeamByID">param object of get team by ID request</param>
        /// <returns>ResponseGeneric with ResponseTeam response object</returns>
        public ResponseGeneric<ResponseTeam, ResponseError> GetTeamByID(ParamsGetTeamByID paramsGetTeamByID)
        {
            // Address Uri
            Uri addressUri = new Uri("team/{team_id}");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCall<ResponseTeam, ResponseError>(_baseAddress, addressUri, paramsData: paramsGetTeamByID, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Get a team's spaces. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="paramsGetTeamSpace">param object of get team space request</param>
        /// <returns>ResponseGeneric with ResponseTeamSpace response object</returns>
        public ResponseGeneric<ResponseTeamSpace, ResponseError> GetTeamSpace(ParamsGetTeamSpace paramsGetTeamSpace)
        {
            // Address Uri
            Uri addressUri = new Uri("team/{team_id}/space");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCall<ResponseTeamSpace, ResponseError>(_baseAddress, addressUri, paramsData: paramsGetTeamSpace, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Get a space's projects. The projects' lists will also be included.
        /// </summary>
        /// <param name="paramsGetSpaceProjects">param object of get space project request</param>
        /// <returns>ResponseGeneric with ResponseSpaceProjects response object</returns>
        public ResponseGeneric<ResponseSpaceProjects, ResponseError> GetSpaceProjects(ParamsGetSpaceProjects paramsGetSpaceProjects)
        {
            // Address Uri
            Uri addressUri = new Uri("space/{space_id}/project");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCall<ResponseSpaceProjects, ResponseError>(_baseAddress, addressUri, paramsData: paramsGetSpaceProjects, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Create List in Project
        /// </summary>
        /// <param name="paramsCreateList">param object of create list request</param>
        /// <param name="requestData">RequestCreateList object</param>
        /// <returns>ResponseGeneric with ModelList response object</returns>
        public ResponseGeneric<ResponseModelList, ResponseError> CreateList(ParamsCreateList paramsCreateList, RequestCreateList requestData)
        {
            // Address Uri
            Uri addressUri = new Uri("space/{project_id}/project");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecutePostCall<ResponseModelList, ResponseError>(_baseAddress, addressUri, paramsData: paramsCreateList, requestData: requestData, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers,
                ContentTypeRequest = "application/json"
            });
        }

        /// <summary>
        /// Edit List informations
        /// </summary>
        /// <param name="paramsEditList">params object of edit list request</param>
        /// <param name="requestData">RequestEditList object</param>
        /// <returns>ResponseGeneric with ModelList response object</returns>
        public ResponseGeneric<ResponseModelList, ResponseError> EditList(ParamsEditList paramsEditList, RequestEditList requestData)
        {
            // Address Uri
            Uri addressUri = new Uri("list/{list_id}/project");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecutePutCall<ResponseModelList, ResponseError>(_baseAddress, addressUri, paramsData: paramsEditList, requestData: requestData, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers,
                ContentTypeRequest = "application/json"
            });
        }

        /// <summary>
        /// Get Tasks of the Team and filter its by optionalParams
        /// </summary>
        /// <param name="paramsGetTasks">params obkect of get tasks request</param>
        /// <param name="optionalParams">OptionalParamsGetTask object</param>
        /// <returns>ResponseGeneric with ResponseTasks response object</returns>
        public ResponseGeneric<ResponseTasks, ResponseError> GetTasks(ParamsGetTasks paramsGetTasks)
        {
            // Address Uri
            Uri addressUri = new Uri("team/{team_id}/task");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCall<ResponseTasks, ResponseError>(_baseAddress, addressUri, paramsData: paramsGetTasks, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Create Task in List.
        /// </summary>
        /// <param name="paramCreateTaskInList">params object of create task in list request</param>
        /// <param name="requestData">RequestCreateTaskInList object</param>
        /// <returns>ResponseGeneric with ModelTask object Expected</returns>
        public ResponseGeneric<ResponseModelTask, ResponseError> CreateTaskInList(ParamsCreateTaskInList paramCreateTaskInList, RequestCreateTaskInList requestData)
        {
            // Address Uri
            Uri addressUri = new Uri("list/{list_id}/task");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecutePostCall<ResponseModelTask, ResponseError>(_baseAddress, addressUri, paramsData: paramCreateTaskInList, requestData: requestData, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers,
                ContentTypeRequest = "application/json"
            });
        }

        /// <summary>
        /// Edit Task informations.
        /// </summary>
        /// <param name="paramsEditTask">param object of Edit Task request</param>
        /// <param name="requestData">RequestEditTask object</param>
        /// <returns>ResponseGeneric with ResponseSuccess response object</returns>
        public ResponseGeneric<ResponseSuccess, ResponseError> EditTask(ParamsEditTask paramsEditTask, RequestEditTask requestData)
        {
            // Address Uri
            Uri addressUri = new Uri("task/{task_id}");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecutePutCall<ResponseSuccess, ResponseError>(_baseAddress, addressUri, paramsData: paramsEditTask, requestData: requestData, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers,
                ContentTypeRequest = "application/json"
            });
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
        /// <param name="paramGetTeamByID">param object of get team by ID request</param>
        /// <returns>ResponseGeneric with ResponseTeam response object</returns>
        public Task<ResponseGeneric<ResponseTeam, ResponseError>> GetTeamByIDAsync(ParamsGetTeamByID paramGetTeamByID)
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
        /// <param name="paramGetTeamSpace">param object of get team space request</param>
        /// <returns>ResponseGeneric with ResponseTeamSpace object expected</returns>
        public Task<ResponseGeneric<ResponseTeamSpace, ResponseError>> GetTeamSpacesAsync(ParamsGetTeamSpace paramGetTeamSpace)
        {
            // Address Uri
            Uri addressUri = new Uri("team/{team_id}/sspace");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCallAsync<ResponseTeamSpace, ResponseError>(_baseAddress, addressUri, paramsData: paramGetTeamSpace, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Get a space's projects. The projects' lists will also be included.
        /// </summary>
        /// <param name="paramsGetSpaceProjects">params object of get space projects request</param>
        /// <returns>ResponseGeneric with ResponseSpaceProjects object expected</returns>
        public Task<ResponseGeneric<ResponseSpaceProjects, ResponseError>> GetSpaceProjectsAsync(ParamsGetSpaceProjects paramsGetSpaceProjects)
        {
            // Address Uri
            Uri addressUri = new Uri("space/{space_id}/project");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCallAsync<ResponseSpaceProjects, ResponseError>(_baseAddress, addressUri, paramsData: paramsGetSpaceProjects, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Create List in Project
        /// </summary>
        /// <param name="paramsCreateList">param object of create list request</param>
        /// <param name="requestData">RequestCreateList object</param>
        /// <returns>ResponseGeneric with ModelList object expected</returns>
        public Task<ResponseGeneric<ResponseModelList, ResponseError>> CreateListAsync(ParamsCreateList paramsCreateList, RequestCreateList requestData)
        {
            // Address Uri
            Uri addressUri = new Uri("project/{project_id}/list");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecutePostCallAsync<ResponseModelList, ResponseError>(_baseAddress, addressUri, paramsData: paramsCreateList, requestData: requestData, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers,
                ContentTypeRequest = "application/json"
            });
        }

        /// <summary>
        /// Edit List informations
        /// </summary>
        /// <param name="paramsEditList">param object of Edi List request</param>
        /// <param name="requestData">RequestEditList object</param>
        /// <returns>ResponseGeneric with ModelList object expected</returns>
        public Task<ResponseGeneric<ResponseModelList, ResponseError>> EditListAsync(ParamsEditList paramsEditList, RequestEditList requestData)
        {
            // Address Uri
            Uri addressUri = new Uri("list/{list_id}");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecutePutCallAsync<ResponseModelList, ResponseError>(_baseAddress, addressUri, paramsData: paramsEditList, requestData: requestData, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers,
                ContentTypeRequest = "application/json"
            });
        }

        /// <summary>
        /// Get Tasks of the Team and filter its by optionalParams
        /// </summary>
        /// <param name="paramsGetTasks">param object of get tasks request</param>
        /// <param name="optionalParams">OptionalParamsGetTask object</param>
        /// <returns>ResponseGeneric with ResponseTasks object expected</returns>
        public Task<ResponseGeneric<ResponseTasks, ResponseError>> GetTasksAsync(ParamsGetTasks paramsGetTasks)
        {
            // Address Uri
            Uri addressUri = new Uri("team/{team_id}/task");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecuteGetCallAsync<ResponseTasks, ResponseError>(_baseAddress, addressUri, paramsData: paramsGetTasks, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Create Task in List.
        /// </summary>
        /// <param name="paramsCreateTaskInList">param object of Create Task in List request</param>
        /// <param name="requestData">RequestCreateTaskInList object</param>
        /// <returns>ResponseGeneric with ModelTask object Expected</returns>
        public Task<ResponseGeneric<ResponseModelTask, ResponseError>> CreateTaskInListAsync(ParamsCreateTaskInList paramsCreateTaskInList, RequestCreateTaskInList requestData)
        {
            // Address Uri
            Uri addressUri = new Uri("list/{list_id}/task");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecutePostCallAsync<ResponseModelTask, ResponseError>(_baseAddress, addressUri, paramsData: paramsCreateTaskInList, requestData: requestData, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        /// <summary>
        /// Edit Task informations.
        /// </summary>
        /// <param name="paramsEditTask">param object of edit task request</param>
        /// <param name="requestData">RequestEditTask object</param>
        /// <returns>ResponseGeneric with ResponseSuccess object expected</returns>
        public Task<ResponseGeneric<ResponseSuccess, ResponseError>> EditTaskAsync(ParamsEditTask paramsEditTask, RequestEditTask requestData)
        {
            // Address Uri
            Uri addressUri = new Uri("task/{task_id}");

            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", _accessToken);

            // Execute Call
            return HttpRequest.ExecutePutCallAsync<ResponseSuccess, ResponseError>(_baseAddress, addressUri, paramsData: paramsEditTask, requestData: requestData, httpRequestOptions: new HttpRequestSettings()
            {
                Headers = headers
            });
        }

        #endregion

    }

}
