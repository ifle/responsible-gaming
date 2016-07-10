using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pinnacle.ResponsibleGaming.ApiClient.Tests
{
    [TestClass]
    public class ResponsibleGamingApiTests
    {
        [TestMethod]
        public  void GetDepositLimit()
        {
            var responsibleGamingApi = new ResponsibleGamingApi();
            var response =  responsibleGamingApi
                            .DepositLimit
                            .GetWithHttpMessagesAsync("testuser");
            var depositLimit = response.Result.Body;
            
            Assert.IsNotNull(depositLimit);
        }
        [TestMethod]
        public void SetDepositLimit()
        {
            var responsibleGamingApi = new ResponsibleGamingApi();
            var response = responsibleGamingApi
                            .DepositLimit
                            .SetWithHttpMessagesAsync("testuser", 100, 7, null, null,"cesarc", "testuser");
            var depositLimit = response.Result.Body;

            Assert.IsNotNull(depositLimit);
        }
    }
}
