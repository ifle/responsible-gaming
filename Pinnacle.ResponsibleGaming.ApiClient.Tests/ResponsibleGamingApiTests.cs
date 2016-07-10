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
        public void SetDepositLimit()
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

            Assert.AreEqual("The limit must be more restrictive", response.Result.Response.ReasonPhrase);
        }
    }
}
