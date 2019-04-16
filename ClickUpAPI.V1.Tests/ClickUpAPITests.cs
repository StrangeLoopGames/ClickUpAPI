using NUnit.Framework;
using PaironsTech.ApiHelper;
using PaironsTech.ClickUpAPI.V1.Params;
using PaironsTech.ClickUpAPI.V1.Responses;
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
        /// Tests of GetTeamByID()
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
                                Assert.That(responseAuthorizedTeams.ResponseSuccess != null, "The ResponseSuccess of the Response of the request 'GetTeamByID' in ShouldGetTeamByID() method is equals to null."); // Always return false
                            }
                        }
                        else
                        {
                            Assert.That(responseAuthorizedTeams.RequestStatus == HttpStatusCode.OK, "The Request Status of the Response of the request 'GetTeamByID' in ShouldGetTeamByID() method is not equals to 200 [OK status]"); // Always return false
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
        /// 
        /// </summary>
        [Test]
        public void ShouldGetTeamSpace()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ShouldGetSpaceProjects()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ShouldCreateList()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ShouldEditList()
        {

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
