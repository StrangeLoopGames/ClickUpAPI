using NUnit.Framework;
using PaironsTech.ApiHelper;
using PaironsTech.ClickUpAPI.V1.Params;
using PaironsTech.ClickUpAPI.V1.Requests;
using PaironsTech.ClickUpAPI.V1.Responses;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System.Net;

namespace PaironsTech.ClickUpAPI.V1.Tests
{

    /// <summary>
    /// Class for tests of object 'ClickUpAPI' in 'PaironsTech.ClickUpAPI.V1'
    /// </summary>
    [TestFixture]
    public class ClickUpAPITests
    {

        /// <summary>
        /// Access Token of ClickUp, used for test request
        /// </summary>
        private static readonly string _accessToken = "pk_RWWD1Y3IV5ZLTI1EOSG9ES48RVYCMZRQ";


        #region Tests Sync Methods

        /// <summary>
        /// Tests of GetAutorizedUser method
        /// </summary>
        [Test]
        public void ShouldGetAuthorizedUser()
        {
            ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
            ResponseGeneric<ResponseAuthorizedUser, ResponseError> response = clickUpAPI.GetAuthorizedUser();
            if (response.RequestStatus == HttpStatusCode.OK)
            {
                if (response.ResponseSuccess != null)
                {
                    Assert.That(response.ResponseSuccess != null); // Always Return True
                }
                else
                {
                    Assert.That(response.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetAuthorizedUser' is equals to null."); // Always return false
                }
            }
            else
            {
                Assert.That(response.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetAuthorizedUser' is not equals to 200 [OK status]"); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetAuthotizedTeams method
        /// </summary>
        [Test]
        public void ShouldGetAuthorizedTeams()
        {
            ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
            ResponseGeneric<ResponseAuthorizedTeams, ResponseError> response = clickUpAPI.GetAuthorizedTeams();
            if (response.RequestStatus == HttpStatusCode.OK)
            {
                if (response.ResponseSuccess != null)
                {
                    Assert.That(response.ResponseSuccess != null); // Always Return True
                }
                else
                {
                    Assert.That(response.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' is equals to null."); // Always return false
                }
            }
            else
            {
                Assert.That(response.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetAuthorizedTeams' is not equals to 200 [OK status]"); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetTeamByID method
        /// </summary>
        [Test]
        public void ShouldGetTeamByID()
        {
            ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);

            // I Donwload a list of teams and I get the first team if exist
            ResponseGeneric<ResponseAuthorizedTeams, ResponseError> responseAuthorizedTeams = clickUpAPI.GetAuthorizedTeams();
            if (responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK)
            {
                if (responseAuthorizedTeams.ResponseSuccess != null)
                {
                    if (responseAuthorizedTeams.ResponseSuccess.Teams.Count != 0)
                    {
                        ResponseGeneric<ResponseTeam, ResponseError> responseGetTeamByID = clickUpAPI.GetTeamByID(new ParamsGetTeamByID()
                        {
                            TeamId = responseAuthorizedTeams.ResponseSuccess.Teams[0].Id
                        });

                        if (responseGetTeamByID.RequestStatus == HttpStatusCode.OK)
                        {
                            if (responseGetTeamByID.ResponseSuccess != null)
                            {
                                Assert.That(responseGetTeamByID.ResponseSuccess != null); // Always return true
                            }
                            else
                            {
                                Assert.That(responseGetTeamByID.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetTeamByID' in ShouldGetTeamByID() method is equals to null."); // Always return false
                            }
                        }
                        else
                        {
                            Assert.That(responseGetTeamByID.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetTeamByID' in ShouldGetTeamByID() method is not equals to 200 [OK status]"); // Always return false
                        }
                    }
                    else
                    {
                        Assert.That(responseAuthorizedTeams.ResponseSuccess.Teams.Count == 0, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' in ShouldGetTeamByID() method not have childs.");   // Always return true
                    }
                }
                else
                {
                    Assert.That(responseAuthorizedTeams.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' in ShouldGetTeamByID() method is equals to null."); // Always return false
                }
            }
            else
            {
                Assert.That(responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetAuthorizedTeams' in ShouldGetTeamByID() method is not equals to 200 [OK status]"); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetTeamSpace method
        /// </summary>
        [Test]
        public void ShouldGetTeamSpace()
        {
            ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);

            // I Donwload a list of teams and I get the first team if exist
            ResponseGeneric<ResponseAuthorizedTeams, ResponseError> responseAuthorizedTeams = clickUpAPI.GetAuthorizedTeams();
            if (responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK)
            {
                if (responseAuthorizedTeams.ResponseSuccess != null)
                {
                    if (responseAuthorizedTeams.ResponseSuccess.Teams.Count != 0)
                    {
                        ResponseGeneric<ResponseTeamSpace, ResponseError> responseGetTeamSpace = clickUpAPI.GetTeamSpace(new ParamsGetTeamSpace()
                        {
                            TeamId = responseAuthorizedTeams.ResponseSuccess.Teams[0].Id
                        });

                        if (responseGetTeamSpace.RequestStatus == HttpStatusCode.OK)
                        {
                            if (responseGetTeamSpace.ResponseSuccess != null)
                            {
                                Assert.That(responseGetTeamSpace.ResponseSuccess != null); // Always return true
                            }
                            else
                            {
                                Assert.That(responseGetTeamSpace.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetTeamSpace' in ShouldGetTeamSpace() method is equals to null."); // Always return false
                            }
                        }
                        else
                        {
                            Assert.That(responseGetTeamSpace.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetTeamSpace' in ShouldGetTeamSpace() method is not equals to 200 [OK status]"); // Always return false
                        }
                    }
                    else
                    {
                        Assert.That(responseAuthorizedTeams.ResponseSuccess.Teams.Count == 0, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' in ShouldGetTeamSpace() method not have childs.");   // Always return true
                    }
                }
                else
                {
                    Assert.That(responseAuthorizedTeams.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' in ShouldGetTeamSpace() method is equals to null."); // Always return false
                }
            }
            else
            {
                Assert.That(responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetAuthorizedTeams' in ShouldGetTeamSpace() method is not equals to 200 [OK status]"); // Always return false
            }
        }

        /// <summary>
        /// Tests of GetSpaceProjects method
        /// </summary>
        [Test]
        public void ShouldGetSpaceProjects()
        {
            ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);

            // I Donwload a list of teams and I get the first team if exist
            ResponseGeneric<ResponseAuthorizedTeams, ResponseError> responseAuthorizedTeams = clickUpAPI.GetAuthorizedTeams();
            if (responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK)
            {
                if (responseAuthorizedTeams.ResponseSuccess != null)
                {
                    if (responseAuthorizedTeams.ResponseSuccess.Teams.Count != 0)
                    {
                        ResponseGeneric<ResponseTeamSpace, ResponseError> responseGetTeamSpace = clickUpAPI.GetTeamSpace(new ParamsGetTeamSpace()
                        {
                            TeamId = responseAuthorizedTeams.ResponseSuccess.Teams[0].Id
                        });

                        if (responseGetTeamSpace.RequestStatus == HttpStatusCode.OK)
                        {
                            if (responseGetTeamSpace.ResponseSuccess != null)
                            {
                                if (responseGetTeamSpace.ResponseSuccess.Spaces.Count != 0)
                                {
                                    ResponseGeneric<ResponseSpaceProjects, ResponseError> responseGetSpaceProjects = clickUpAPI.GetSpaceProjects(new ParamsGetSpaceProjects()
                                    {
                                        SpaceId = responseGetTeamSpace.ResponseSuccess.Spaces[0].Id
                                    });

                                    if (responseGetSpaceProjects.RequestStatus == HttpStatusCode.OK)
                                    {
                                        if (responseGetSpaceProjects.ResponseSuccess != null)
                                        {
                                            Assert.That(responseGetSpaceProjects.ResponseSuccess != null); // Always return true
                                        }
                                        else
                                        {
                                            Assert.That(responseGetSpaceProjects.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetSpaceProjects' in ShouldGetSpaceProjects() method is equals to null."); // Always return false
                                        }
                                    }
                                    else
                                    {
                                        Assert.That(responseGetSpaceProjects.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetSpaceProjects' in ShouldGetSpaceProjects() method is not equals to 200 [OK status]"); // Always return false
                                    }
                                }
                                else
                                {
                                    Assert.That(responseGetTeamSpace.ResponseSuccess.Spaces.Count != 0, "The ResponseSuccess of the Response of the request 'GetTeamSpace' in ShouldGetSpaceProjects() method return 0 spaces. If thereisn't spaces test can be able to access at Space Id and test 'GetSpaceProjects' method"); // Always return false
                                }
                            }
                            else
                            {
                                Assert.That(responseGetTeamSpace.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetTeamSpace' in ShouldGetSpaceProjects() method is equals to null."); // Always return false
                            }
                        }
                        else
                        {
                            Assert.That(responseGetTeamSpace.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetTeamSpace' in ShouldGetSpaceProjects() method is not equals to 200 [OK status]"); // Always return false
                        }
                    }
                    else
                    {
                        Assert.That(responseAuthorizedTeams.ResponseSuccess.Teams.Count == 0, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' in ShouldGetSpaceProjects() method not have childs.");   // Always return true
                    }
                }
                else
                {
                    Assert.That(responseAuthorizedTeams.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' in ShouldGetSpaceProjects() method is equals to null."); // Always return false
                }
            }
            else
            {
                Assert.That(responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetAuthorizedTeams' in ShouldGetSpaceProjects() method is not equals to 200 [OK status]"); // Always return false
            }
        }

        /// <summary>
        /// Tests of CreateList method
        /// </summary>
        [Test]
        public void ShouldCreateList()
        {
            ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);

            // I Donwload a list of teams and I get the first team if exist
            ResponseGeneric<ResponseAuthorizedTeams, ResponseError> responseAuthorizedTeams = clickUpAPI.GetAuthorizedTeams();
            if (responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK)
            {
                if (responseAuthorizedTeams.ResponseSuccess != null)
                {
                    if (responseAuthorizedTeams.ResponseSuccess.Teams.Count != 0)
                    {
                        ResponseGeneric<ResponseTeamSpace, ResponseError> responseGetTeamSpace = clickUpAPI.GetTeamSpace(new ParamsGetTeamSpace()
                        {
                            TeamId = responseAuthorizedTeams.ResponseSuccess.Teams[0].Id
                        });

                        if (responseGetTeamSpace.RequestStatus == HttpStatusCode.OK)
                        {
                            if (responseGetTeamSpace.ResponseSuccess != null)
                            {
                                if (responseGetTeamSpace.ResponseSuccess.Spaces.Count != 0)
                                {
                                    ResponseGeneric<ResponseSpaceProjects, ResponseError> responseGetSpaceProjects = clickUpAPI.GetSpaceProjects(new ParamsGetSpaceProjects()
                                    {
                                        SpaceId = responseGetTeamSpace.ResponseSuccess.Spaces[0].Id
                                    });

                                    if (responseGetSpaceProjects.RequestStatus == HttpStatusCode.OK)
                                    {
                                        if (responseGetSpaceProjects.ResponseSuccess != null)
                                        {
                                            if (responseGetSpaceProjects.ResponseSuccess.Projects.Count != 0)
                                            {
                                                ResponseGeneric<ResponseModelList, ResponseError> responseCreateList = clickUpAPI.CreateList
                                                (
                                                    new ParamsCreateList()
                                                    {
                                                        ProjectId = responseGetSpaceProjects.ResponseSuccess.Projects[0].Id
                                                    },
                                                    new RequestCreateList()
                                                    {
                                                        Name = "New List From ClickUpAPI.V1.Tests"
                                                    }
                                                );

                                                if (responseCreateList.RequestStatus == HttpStatusCode.OK)
                                                {
                                                    if (responseCreateList.ResponseSuccess != null)
                                                    {
                                                        Assert.That(responseCreateList.ResponseSuccess != null); // Always return true
                                                    }
                                                    else
                                                    {
                                                        Assert.That(responseCreateList.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'CreateList' in ShouldCreateList() method is equals to null."); // Always return false
                                                    }
                                                }
                                                else
                                                {
                                                    Assert.That(responseCreateList.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'CreateList' in ShouldCreateList() method is not equals to 200 [OK status]"); // Always return false
                                                }
                                            }
                                            else
                                            {
                                                Assert.That(responseGetSpaceProjects.ResponseSuccess.Projects.Count != 0, "The ResponseSuccess of the Response of the request 'GetSpaceProjects' in ShouldCreateList() method return 0 projects. If there isn't project, test can not be able to access at project Id and test 'CreateList' method"); // Always return false
                                            }
                                        }
                                        else
                                        {
                                            Assert.That(responseGetSpaceProjects.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetSpaceProjects' in ShouldCreateList() method is equals to null."); // Always return false
                                        }
                                    }
                                    else
                                    {
                                        Assert.That(responseGetSpaceProjects.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetSpaceProjects' in ShouldCreateList() method is not equals to 200 [OK status]"); // Always return false
                                    }
                                }
                                else
                                {
                                    Assert.That(responseGetTeamSpace.ResponseSuccess.Spaces.Count != 0, "The ResponseSuccess of the Response of the request 'GetTeamSpace' in ShouldCreateList() method return 0 spaces. If thereisn't spaces test can be able to access at Space Id and test 'GetSpaceProjects' method"); // Always return false
                                }
                            }
                            else
                            {
                                Assert.That(responseGetTeamSpace.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetTeamSpace' in ShouldCreateList() method is equals to null."); // Always return false
                            }
                        }
                        else
                        {
                            Assert.That(responseGetTeamSpace.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetTeamSpace' in ShouldCreateList() method is not equals to 200 [OK status]"); // Always return false
                        }
                    }
                    else
                    {
                        Assert.That(responseAuthorizedTeams.ResponseSuccess.Teams.Count == 0, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' in ShouldCreateList() method not have childs.");   // Always return true
                    }
                }
                else
                {
                    Assert.That(responseAuthorizedTeams.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' in ShouldCreateList() method is equals to null."); // Always return false
                }
            }
            else
            {
                Assert.That(responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetAuthorizedTeams' in ShouldCreateList() method is not equals to 200 [OK status]"); // Always return false
            }
        }

        /// <summary>
        /// Tests of EditList method
        /// </summary>
        [Test]
        public void ShouldEditList()
        {
            ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);

            // I Donwload a list of teams and I get the first team if exist
            ResponseGeneric<ResponseAuthorizedTeams, ResponseError> responseAuthorizedTeams = clickUpAPI.GetAuthorizedTeams();
            if (responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK)
            {
                if (responseAuthorizedTeams.ResponseSuccess != null)
                {
                    if (responseAuthorizedTeams.ResponseSuccess.Teams.Count != 0)
                    {
                        ResponseGeneric<ResponseTeamSpace, ResponseError> responseGetTeamSpace = clickUpAPI.GetTeamSpace(new ParamsGetTeamSpace()
                        {
                            TeamId = responseAuthorizedTeams.ResponseSuccess.Teams[0].Id
                        });

                        if (responseGetTeamSpace.RequestStatus == HttpStatusCode.OK)
                        {
                            if (responseGetTeamSpace.ResponseSuccess != null)
                            {
                                if (responseGetTeamSpace.ResponseSuccess.Spaces.Count != 0)
                                {
                                    ResponseGeneric<ResponseSpaceProjects, ResponseError> responseGetSpaceProjects = clickUpAPI.GetSpaceProjects(new ParamsGetSpaceProjects()
                                    {
                                        SpaceId = responseGetTeamSpace.ResponseSuccess.Spaces[0].Id
                                    });

                                    if (responseGetSpaceProjects.RequestStatus == HttpStatusCode.OK)
                                    {
                                        if (responseGetSpaceProjects.ResponseSuccess != null)
                                        {
                                            if (responseGetSpaceProjects.ResponseSuccess.Projects.Count != 0)
                                            {
                                                ResponseGeneric<ResponseModelList, ResponseError> responseCreateList = clickUpAPI.CreateList
                                                (
                                                    new ParamsCreateList()
                                                    {
                                                        ProjectId = responseGetSpaceProjects.ResponseSuccess.Projects[0].Id
                                                    },
                                                    new RequestCreateList()
                                                    {
                                                        Name = "New List From ClickUpAPI.V1.Tests to Edit"
                                                    }
                                                );

                                                if (responseCreateList.RequestStatus == HttpStatusCode.OK)
                                                {
                                                    if (responseCreateList.ResponseSuccess != null)
                                                    {
                                                        ResponseGeneric<ResponseModelList, ResponseError> responseEditList = clickUpAPI.EditList
                                                        (
                                                            new ParamsEditList()
                                                            {
                                                                ListId = responseCreateList.ResponseSuccess.Id
                                                            },
                                                            new RequestEditList()
                                                            {
                                                                Name = "List Edit From ClickUpAPI.V1.Tests"
                                                            }
                                                        );

                                                        if (responseEditList.RequestStatus == HttpStatusCode.OK)
                                                        {
                                                            if (responseEditList.ResponseSuccess != null)
                                                            {
                                                                Assert.That(responseEditList.ResponseSuccess != null); // Always return true
                                                            }
                                                            else
                                                            {
                                                                Assert.That(responseCreateList.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'EditList' in ShouldEditList() method is equals to null."); // Always return false
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Assert.That(responseCreateList.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'EditList' in ShouldEditList() method is not equals to 200 [OK status]"); // Always return false
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Assert.That(responseCreateList.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'CreateList' in ShouldEditList() method is equals to null."); // Always return false
                                                    }
                                                }
                                                else
                                                {
                                                    Assert.That(responseCreateList.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'CreateList' in ShouldEditList() method is not equals to 200 [OK status]"); // Always return false
                                                }
                                            }
                                            else
                                            {
                                                Assert.That(responseGetSpaceProjects.ResponseSuccess.Projects.Count != 0, "The ResponseSuccess of the Response of the request 'GetSpaceProjects' in ShouldEditList() method return 0 projects. If there isn't project, test can not be able to access at project Id and test 'CreateList' method"); // Always return false
                                            }
                                        }
                                        else
                                        {
                                            Assert.That(responseGetSpaceProjects.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetSpaceProjects' in ShouldEditList() method is equals to null."); // Always return false
                                        }
                                    }
                                    else
                                    {
                                        Assert.That(responseGetSpaceProjects.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetSpaceProjects' in ShouldEditList() method is not equals to 200 [OK status]"); // Always return false
                                    }
                                }
                                else
                                {
                                    Assert.That(responseGetTeamSpace.ResponseSuccess.Spaces.Count != 0, "The ResponseSuccess of the Response of the request 'GetTeamSpace' in ShouldEditList() method return 0 spaces. If thereisn't spaces test can be able to access at Space Id and test 'GetSpaceProjects' method"); // Always return false
                                }
                            }
                            else
                            {
                                Assert.That(responseGetTeamSpace.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetTeamSpace' in ShouldEditList() method is equals to null."); // Always return false
                            }
                        }
                        else
                        {
                            Assert.That(responseGetTeamSpace.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetTeamSpace' in ShouldEditList() method is not equals to 200 [OK status]"); // Always return false
                        }
                    }
                    else
                    {
                        Assert.That(responseAuthorizedTeams.ResponseSuccess.Teams.Count == 0, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' in ShouldEditList() method not have childs.");   // Always return true
                    }
                }
                else
                {
                    Assert.That(responseAuthorizedTeams.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetAuthorizedTeams' in ShouldEditList() method is equals to null."); // Always return false
                }
            }
            else
            {
                Assert.That(responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetAuthorizedTeams' in ShouldEditList() method is not equals to 200 [OK status]"); // Always return false
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ShouldGetTasks()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ShouldCreateTaskInList()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ShouldEditTask()
        {

        }

        #endregion

        #region Test Async Methods


        #endregion

    }

}
