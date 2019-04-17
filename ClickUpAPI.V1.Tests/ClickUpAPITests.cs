using NUnit.Framework;
using PaironsTech.ApiHelper;
using PaironsTech.ClickUpAPI.V1.Enums;
using PaironsTech.ClickUpAPI.V1.Params;
using PaironsTech.ClickUpAPI.V1.Requests;
using PaironsTech.ClickUpAPI.V1.Responses;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System;
using System.Collections.Generic;
using System.Net;

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
                ResponseGeneric<ResponseTeam, ResponseError> responseTeamById = clickUpAPI.GetTeamByID(new ParamsGetTeamByID() { TeamId = _teamId });
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
                ResponseGeneric<ResponseTeamSpace, ResponseError> responseTeamSpace = clickUpAPI.GetTeamSpace(new ParamsGetTeamSpace() { TeamId = _teamId });
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
                ResponseGeneric<ResponseSpaceProjects, ResponseError> responseSpaceProjects = clickUpAPI.GetSpaceProjects(new ParamsGetSpaceProjects() { SpaceId = _spaceId });
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
                    new ParamsCreateList() { ProjectId = _projectId },
                    new RequestCreateList()
                    {
                        Name = "New List created from ClickUpAPI.V1.Test"
                    }
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
                    new ParamsEditList() { ListId = _listId },
                    new RequestEditList()
                    {
                        Name = "Edit List from ClickUpAPI.V1.Test "
                    }
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
                    new ParamsGetTasks()
                    {
                        TeamId = _teamId,
                        ListIds = new List<string>()
                        {
                            _listId, _listId
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
                    new ParamsCreateTaskInList()
                    {
                        ListId = _listId
                    },
                    new RequestCreateTaskInList()
                    {
                        Name = "New Task created from tests of ClickUpAPI.V1",
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
                    new ParamsEditTask()
                    {
                        TaskId = _taskId,
                    },
                    new RequestEditTask()
                    {
                        Name = "Task edited from tests of ClickUpAPI.V1"
                    }
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


        #endregion

    }

}
