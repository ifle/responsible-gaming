using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pinnacle.ResponsibleGaming.ApiClient.Models;

namespace Pinnacle.ResponsibleGaming.ApiClient.Tests
{
    [TestClass]
    public class ResponsibleGamingApiTests
    {
        [TestMethod]
        public  void GetDepositLimit()
        {
            var responsibleGamingApi = new PinnacleResponsibleGamingApi();
            var response =  responsibleGamingApi
                            .DepositLimit
                            .GetWithHttpMessagesAsync("testuser");
            var depositLimit = response.Result.Body;
            
            Assert.IsNotNull(depositLimit);
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void SetDepositLimit_BadRequest()
        {
            var setDepositLimitRequest = new SetDepositLimit
            {
                Amount = 100,
                PeriodInDays = 7
            };
            var responsibleGamingApi = new PinnacleResponsibleGamingApi();
            var response = responsibleGamingApi
                            .DepositLimit
                            .SetWithHttpMessagesAsync("testuser", setDepositLimitRequest);

            Assert.IsTrue(response.Result.Response.StatusCode == HttpStatusCode.BadRequest);
        }
      
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void SetDepositLimit_Conflict()
        {
            var setDepositLimitRequest= new SetDepositLimit
                                        {
                                            Amount = 100,
                                            PeriodInDays = 7,
                                            Author = "cesarc"
                                        };
            var responsibleGamingApi = new PinnacleResponsibleGamingApi();
            var response = responsibleGamingApi
                            .DepositLimit
                            .SetWithHttpMessagesAsync("testuser", setDepositLimitRequest);

            Assert.IsTrue(response.Result.Response.StatusCode == HttpStatusCode.Conflict);
            Assert.AreEqual("The limit must be more restrictive", response.Result.Response.ReasonPhrase);
        }
    }
}
