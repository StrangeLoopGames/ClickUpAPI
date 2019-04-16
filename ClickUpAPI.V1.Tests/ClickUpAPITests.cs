using NUnit.Framework;
using PaironsTech.ApiHelper;
using PaironsTech.ClickUpAPI.V1;
using PaironsTech.ClickUpAPI.V1.Responses;
using System;

namespace PaironsTech.ClickUpAPI.V1.Tests
{

    [TestFixture]
    public class ClickUpAPITests
    {

        private static readonly string _accessToken = "pk_RWWD1Y3IV5ZLTI1EOSG9ES48RVYCMZRQ";


        [Test]
        public void ShouldGetAuthorizedUser()
        {
            ClickUpAPI clickUpAPI = new ClickUpAPI(_accessToken);
            ResponseGeneric<ResponseAuthorizedUser, ResponseError> response = clickUpAPI.GetAuthorizedUser();
            Assert.That(response.ResponseSuccess != null);
        }



    }

}
