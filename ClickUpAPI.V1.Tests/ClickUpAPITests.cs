using NUnit.Framework;
using PaironsTech.ApiHelper;
using PaironsTech.ClickUpAPI.V1.Enums;
using PaironsTech.ClickUpAPI.V1.Params;
using PaironsTech.ClickUpAPI.V1.Requests;
using PaironsTech.ClickUpAPI.V1.Responses;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaironsTech.ClickUpAPI.V1.Tests
{

    /// <summary>
    /// Class for tests of object 'ClickUpAPI' in 'PaironsTech.ClickUpAPI.V1'
    /// </summary>
    [TestFixture]
    public class ClickUpAPITests
    {

        #region Private Test Variables

        /// <summary>
        /// Access Token of ClickUp, used for test request
        /// </summary>
        private static readonly string _accessToken = "pk_1O9TG5WQIC8E656880JH8KITR28W4V3A";

        /// <summary>
        /// The Team Id used for test request
        /// </summary>
        private static readonly string _teamId = "2180065";

        /// <summary>
        /// The Space Id used for test request
        /// </summary>
        private static readonly string _spaceId = "2271405";

        /// <summary>
        /// The Project Id used for test request
        /// </summary>
        private static readonly string _projectId = "2697881";

        /// <summary>
        /// The List Id used for test request
        /// </summary>
        private static readonly string _listId = "4230623";

        /// <summary>
        /// The Task Id used for test request
        /// </summary>
        private static readonly string _taskId = "tdnaf";

        #endregion


        #region Tests Sync Methods

        /// <summary>
        /// Tests of GetAutorizedUser method
        /// </summary>
        [Test]
        public void ShouldGetAuthorizedUser()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseAuthorizedUser, ResponseError> responseAuthorizedUser = clickUpAPI.GetAuthorizedUser();
                if (responseAuthorizedUser != null)
                {
                    if (responseAuthorizedUser.ResponseSuccess != null || responseAuthorizedUser.ResponseError != null)
                    {
                        Assert.That(responseAuthorizedUser.ResponseSuccess != null || responseAuthorizedUser.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseAuthorizedUser.ResponseSuccess != null || responseAuthorizedUser.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse  of the request through the method 'GetAuthorizedUser' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseAuthorizedUser != null, "The Response of the request through the method 'GetAuthorizedUser' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetAuthorizedUser' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetAuthotizedTeams method
        /// </summary>
        [Test]
        public void ShouldGetAuthorizedTeams()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseAuthorizedTeams, ResponseError> responseAuthorizedTeams = clickUpAPI.GetAuthorizedTeams();
                if (responseAuthorizedTeams != null)
                {
                    if (responseAuthorizedTeams.ResponseSuccess != null || responseAuthorizedTeams.ResponseError != null)
                    {
                        Assert.That(responseAuthorizedTeams.ResponseSuccess != null || responseAuthorizedTeams.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseAuthorizedTeams.ResponseSuccess != null || responseAuthorizedTeams.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'GetAuthorizedTeams' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseAuthorizedTeams != null, "The Response of the request through the method 'GetAuthorizedTeams' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetAuthorizedTeams' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetTeamByID method
        /// </summary>
        [Test]
        public void ShouldGetTeamByID()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseTeam, ResponseError> responseTeamById = clickUpAPI.GetTeamByID(new ParamsGetTeamByID(_teamId));
                if (responseTeamById != null)
                {
                    if (responseTeamById.ResponseSuccess != null || responseTeamById.ResponseError != null)
                    {
                        Assert.That(responseTeamById.ResponseSuccess != null || responseTeamById.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseTeamById.ResponseSuccess != null || responseTeamById.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'GetTeamByID' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseTeamById != null, "The Response of the request through the method 'GetTeamByID' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetTeamByID' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetTeamSpace method
        /// </summary>
        [Test]
        public void ShouldGetTeamSpace()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseTeamSpace, ResponseError> responseTeamSpace = clickUpAPI.GetTeamSpace(new ParamsGetTeamSpace(_teamId));
                if (responseTeamSpace != null)
                {
                    if (responseTeamSpace.ResponseSuccess != null || responseTeamSpace.ResponseError != null)
                    {
                        Assert.That(responseTeamSpace.ResponseSuccess != null || responseTeamSpace.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseTeamSpace.ResponseSuccess != null || responseTeamSpace.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'GetTeamSpace' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseTeamSpace != null, "The Response of the request through the method 'GetTeamSpace' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetTeamSpace' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetSpaceProjects method
        /// </summary>
        [Test]
        public void ShouldGetSpaceProjects()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseSpaceProjects, ResponseError> responseSpaceProjects = clickUpAPI.GetSpaceProjects(new ParamsGetSpaceProjects(_spaceId));
                if (responseSpaceProjects != null)
                {
                    if (responseSpaceProjects.ResponseSuccess != null || responseSpaceProjects.ResponseError != null)
                    {
                        Assert.That(responseSpaceProjects.ResponseSuccess != null || responseSpaceProjects.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseSpaceProjects.ResponseSuccess != null || responseSpaceProjects.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'GetSpaceProjects' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseSpaceProjects != null, "The Response of the request through the method 'GetSpaceProjects' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetSpaceProjects' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of CreateList method
        /// </summary>
        [Test]
        public void ShouldCreateList()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseModelList, ResponseError> responseCreateList = clickUpAPI.CreateList
                (
                    new ParamsCreateList(_projectId),
                    new RequestCreateList("New List created from ClickUpAPI.V1.Test")
                );
                if (responseCreateList != null)
                {
                    if (responseCreateList.ResponseSuccess != null || responseCreateList.ResponseError != null)
                    {
                        Assert.That(responseCreateList.ResponseSuccess != null || responseCreateList.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseCreateList.ResponseSuccess != null || responseCreateList.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'CreateList' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseCreateList != null, "The Response of the request through the method 'CreateList' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'CreateList' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of EditList method
        /// </summary>
        [Test]
        public void ShouldEditList()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseModelList, ResponseError> responseEditList = clickUpAPI.EditList
                (
                    new ParamsEditList(_listId),
                    new RequestEditList("Edit List from ClickUpAPI.V1.Test")
                );
                if (responseEditList != null)
                {
                    if (responseEditList.ResponseSuccess != null || responseEditList.ResponseError != null)
                    {
                        Assert.That(responseEditList.ResponseSuccess != null || responseEditList.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseEditList.ResponseSuccess != null || responseEditList.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'EditList' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseEditList != null, "The Response of the request through the method 'EditList' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'EditList' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetTasks method
        /// </summary>
        [Test]
        public void ShouldGetTasks()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseTasks, ResponseError> responseGetTasks = clickUpAPI.GetTasks
                (
                    new ParamsGetTasks(_teamId)
                    {
                        ListIds = new List<string>()
                        {
                            _listId
                        }
                    }
                );
                if (responseGetTasks != null)
                {
                    if (responseGetTasks.ResponseSuccess != null || responseGetTasks.ResponseError != null)
                    {
                        Assert.That(responseGetTasks.ResponseSuccess != null || responseGetTasks.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseGetTasks.ResponseSuccess != null || responseGetTasks.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'GetTasks' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseGetTasks != null, "The Response of the request through the method 'GetTasks' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetTasks' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of CreateTaskInList method
        /// </summary>
        [Test]
        public void ShouldCreateTaskInList()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseModelTask, ResponseError> responseCreateTaskInList = clickUpAPI.CreateTaskInList
                (
                    new ParamsCreateTaskInList(_listId),
                    new RequestCreateTaskInList("New Task created from tests of ClickUpAPI.V1")
                    {
                        DueDate = new DateTime(2022, 04, 17, 15, 17, 13),
                        Priority = TaskPriority.Low
                    }
                );
                if (responseCreateTaskInList != null)
                {
                    if (responseCreateTaskInList.ResponseSuccess != null || responseCreateTaskInList.ResponseError != null)
                    {
                        Assert.That(responseCreateTaskInList.ResponseSuccess != null || responseCreateTaskInList.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseCreateTaskInList.ResponseSuccess != null || responseCreateTaskInList.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'CreateTaskInList' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseCreateTaskInList != null, "The Response of the request through the method 'CreateTaskInList' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'CreateTaskInList' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of EditTask method
        /// </summary>
        [Test]
        public void ShouldEditTask()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseSuccess, ResponseError> responseEditTask = clickUpAPI.EditTask
                (
                    new ParamsEditTask(_taskId),
                    new RequestEditTask("Task edited from tests of ClickUpAPI.V1")
                );
                if (responseEditTask != null)
                {
                    if (responseEditTask.ResponseSuccess != null || responseEditTask.ResponseError != null)
                    {
                        Assert.That(responseEditTask.ResponseSuccess != null || responseEditTask.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseEditTask.ResponseSuccess != null || responseEditTask.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'EditTask' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseEditTask != null, "The Response of the request through the method 'EditTask' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'EditTask' generate exception: " + ex.Message); // Always return false
            }
        }

        #endregion


        #region Test Async Methods

        /// <summary>
        /// Tests of GetAutorizedUserAsync method
        /// </summary>
        [Test]
        public void ShouldGetAuthorizedUserAsync()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseAuthorizedUser, ResponseError> responseAuthorizedUser = null;

                Task.Run(async () =>
                {
                    responseAuthorizedUser = await clickUpAPI.GetAuthorizedUserAsync();
                })
                .Wait();

                if (responseAuthorizedUser != null)
                {
                    if (responseAuthorizedUser.ResponseSuccess != null || responseAuthorizedUser.ResponseError != null)
                    {
                        Assert.That(responseAuthorizedUser.ResponseSuccess != null || responseAuthorizedUser.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseAuthorizedUser.ResponseSuccess != null || responseAuthorizedUser.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse  of the request through the method 'GetAuthorizedUserAsync' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseAuthorizedUser != null, "The Response of the request through the method 'GetAuthorizedUserAsync' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetAuthorizedUserAsync' generate exception: " + ex.Message); // Always return false
            }
        }
        
        /// <summary>
        /// Tests of GetAuthotizedTeamsAsync method
        /// </summary>
        [Test]
        public void ShouldGetAuthorizedTeamsAsync()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseAuthorizedTeams, ResponseError> responseAuthorizedTeams = null;

                Task.Run(async () =>
                {
                    responseAuthorizedTeams = await clickUpAPI.GetAuthorizedTeamsAsync();
                })
                .Wait();

                if (responseAuthorizedTeams != null)
                {
                    if (responseAuthorizedTeams.ResponseSuccess != null || responseAuthorizedTeams.ResponseError != null)
                    {
                        Assert.That(responseAuthorizedTeams.ResponseSuccess != null || responseAuthorizedTeams.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseAuthorizedTeams.ResponseSuccess != null || responseAuthorizedTeams.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'GetAuthorizedTeamsAsync' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseAuthorizedTeams != null, "The Response of the request through the method 'GetAuthorizedTeamsAsync' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetAuthorizedTeamsAsync' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetTeamByIDAsync method
        /// </summary>
        [Test]
        public void ShouldGetTeamByIDAsync()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseTeam, ResponseError> responseTeamById = null;

                Task.Run(async () =>
                {
                    responseTeamById = await clickUpAPI.GetTeamByIDAsync(new ParamsGetTeamByID(_teamId));
                })
                .Wait();

                if (responseTeamById != null)
                {
                    if (responseTeamById.ResponseSuccess != null || responseTeamById.ResponseError != null)
                    {
                        Assert.That(responseTeamById.ResponseSuccess != null || responseTeamById.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseTeamById.ResponseSuccess != null || responseTeamById.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'GetTeamByIDAsync' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseTeamById != null, "The Response of the request through the method 'GetTeamByIDAsync' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetTeamByIDAsync' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetTeamSpaceAsync method
        /// </summary>
        [Test]
        public void ShouldGetTeamSpaceAsync()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseTeamSpace, ResponseError> responseTeamSpace = null;

                Task.Run(async () =>
                {
                    responseTeamSpace = await clickUpAPI.GetTeamSpacesAsync(new ParamsGetTeamSpace(_teamId));
                })
                .Wait();

                if (responseTeamSpace != null)
                {
                    if (responseTeamSpace.ResponseSuccess != null || responseTeamSpace.ResponseError != null)
                    {
                        Assert.That(responseTeamSpace.ResponseSuccess != null || responseTeamSpace.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseTeamSpace.ResponseSuccess != null || responseTeamSpace.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'GetTeamSpacesAsync' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseTeamSpace != null, "The Response of the request through the method 'GetTeamSpacesAsync' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetTeamSpacesAsync' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetSpaceProjectsAsync method
        /// </summary>
        [Test]
        public void ShouldGetSpaceProjectsAsync()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseSpaceProjects, ResponseError> responseSpaceProjects = null;

                Task.Run(async () =>
                {
                    responseSpaceProjects = await clickUpAPI.GetSpaceProjectsAsync(new ParamsGetSpaceProjects(_spaceId));
                })
                .Wait();

                if (responseSpaceProjects != null)
                {
                    if (responseSpaceProjects.ResponseSuccess != null || responseSpaceProjects.ResponseError != null)
                    {
                        Assert.That(responseSpaceProjects.ResponseSuccess != null || responseSpaceProjects.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseSpaceProjects.ResponseSuccess != null || responseSpaceProjects.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'GetSpaceProjectsAsync' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseSpaceProjects != null, "The Response of the request through the method 'GetSpaceProjectsAsync' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetSpaceProjectsAsync' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of CreateListAsync method
        /// </summary>
        [Test]
        public void ShouldCreateListAsync()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseModelList, ResponseError> responseCreateList = null;

                Task.Run(async () =>
                {
                    responseCreateList = await clickUpAPI.CreateListAsync
                    (
                        new ParamsCreateList(_projectId),
                        new RequestCreateList("New List created from ClickUpAPI.V1.Test")
                    );
                })
                .Wait();

                if (responseCreateList != null)
                {
                    if (responseCreateList.ResponseSuccess != null || responseCreateList.ResponseError != null)
                    {
                        Assert.That(responseCreateList.ResponseSuccess != null || responseCreateList.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseCreateList.ResponseSuccess != null || responseCreateList.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'CreateListAsync' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseCreateList != null, "The Response of the request through the method 'CreateListAsync' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'CreateListAsync' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of EditListAsync method
        /// </summary>
        [Test]
        public void ShouldEditListAsync()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseModelList, ResponseError> responseEditList = null;

                Task.Run(async () =>
                {
                    responseEditList = await clickUpAPI.EditListAsync
                    (
                        new ParamsEditList(_listId),
                        new RequestEditList("Edit List from ClickUpAPI.V1.Test")
                    );
                })
                .Wait();

                if (responseEditList != null)
                {
                    if (responseEditList.ResponseSuccess != null || responseEditList.ResponseError != null)
                    {
                        Assert.That(responseEditList.ResponseSuccess != null || responseEditList.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseEditList.ResponseSuccess != null || responseEditList.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'EditListAsync' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseEditList != null, "The Response of the request through the method 'EditListAsync' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'EditListAsync' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetTasksAsync method
        /// </summary>
        [Test]
        public void ShouldGetTasksAsync()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseTasks, ResponseError> responseGetTasks = null;

                Task.Run(async () =>
                {
                    responseGetTasks = await clickUpAPI.GetTasksAsync
                    (
                        new ParamsGetTasks(_teamId)
                        {
                            ListIds = new List<string>()
                            {
                                _listId
                            }
                        }
                    );
                })
                .Wait();

                if (responseGetTasks != null)
                {
                    if (responseGetTasks.ResponseSuccess != null || responseGetTasks.ResponseError != null)
                    {
                        Assert.That(responseGetTasks.ResponseSuccess != null || responseGetTasks.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseGetTasks.ResponseSuccess != null || responseGetTasks.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'GetTasksAsync' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseGetTasks != null, "The Response of the request through the method 'GetTasksAsync' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'GetTasksAsync' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of CreateTaskInListAsync method
        /// </summary>
        [Test]
        public void ShouldCreateTaskInListAsync()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseModelTask, ResponseError> responseCreateTaskInList = null;

                Task.Run(async () =>
                {
                    responseCreateTaskInList = await clickUpAPI.CreateTaskInListAsync
                    (
                        new ParamsCreateTaskInList(_listId),
                        new RequestCreateTaskInList("New Task created from tests of ClickUpAPI.V1")
                        {
                            DueDate = new DateTime(2022, 04, 17, 15, 17, 13),
                            Priority = TaskPriority.Low
                        }
                    );
                })
                .Wait();

                if (responseCreateTaskInList != null)
                {
                    if (responseCreateTaskInList.ResponseSuccess != null || responseCreateTaskInList.ResponseError != null)
                    {
                        Assert.That(responseCreateTaskInList.ResponseSuccess != null || responseCreateTaskInList.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseCreateTaskInList.ResponseSuccess != null || responseCreateTaskInList.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'CreateTaskInListAsync' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseCreateTaskInList != null, "The Response of the request through the method 'CreateTaskInListAsync' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'CreateTaskInListAsync' generate exception: " + ex.Message); // Always return false
            }
        }

        /// <summary>
        /// Tests of EditTaskAsync method
        /// </summary>
        [Test]
        public void ShouldEditTaskAsync()
        {
            try
            {
                ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
                ResponseGeneric<ResponseSuccess, ResponseError> responseEditTask = null;

                Task.Run(async () =>
                {
                    responseEditTask = await clickUpAPI.EditTaskAsync
                    (
                        new ParamsEditTask(_taskId),
                        new RequestEditTask("Task edited from tests of ClickUpAPI.V1")
                    );
                })
                .Wait();

                if (responseEditTask != null)
                {
                    if (responseEditTask.ResponseSuccess != null || responseEditTask.ResponseError != null)
                    {
                        Assert.That(responseEditTask.ResponseSuccess != null || responseEditTask.ResponseError != null);
                    }
                    else
                    {
                        Assert.That(responseEditTask.ResponseSuccess != null || responseEditTask.ResponseError != null, "The ResponseSuccess and the ResponseError of the GenericResponse of the request through the method 'EditTaskAsync' are null!"); // Always return false
                    }
                }
                else
                {
                    Assert.That(responseEditTask != null, "The Response of the request through the method 'EditTaskAsync' is null!"); // Always return false
                }
            }
            catch (Exception ex)
            {
                Assert.That(true == false, "The Test Method of 'EditTaskAsync' generate exception: " + ex.Message); // Always return false
            }
        }

        #endregion

    }

}
