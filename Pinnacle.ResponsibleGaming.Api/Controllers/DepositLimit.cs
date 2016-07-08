using System.Threading.Tasks;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Api.Constants;

namespace Pinnacle.ResponsibleGaming.Api.Controllers
{
    public  class DepositLimitController : ApiController
    {
        private readonly Application.GetDepositLimit.Handler _getDepositLimitHandler;
        private readonly Application.SetDepositLimit.Handler _setDepositLimitHandler;
        private readonly Application.DisableDepositLimit.Handler _disableDepositLimitHandler;

        public DepositLimitController(
            Application.GetDepositLimit.Handler getDepositLimitHandler,
            Application.SetDepositLimit.Handler setDepositLimitHandler,
            Application.DisableDepositLimit.Handler disableDepositLimitHandler
            )
        {
            _getDepositLimitHandler = getDepositLimitHandler;
            _setDepositLimitHandler = setDepositLimitHandler;
            _disableDepositLimitHandler = disableDepositLimitHandler;
        }

        [HttpGet]
        [Route(ResourceNames.DepositLimit)]
        public async Task<IHttpActionResult> Get(string customerId)
        {
            var request = new Application.GetDepositLimit.Request { CustomerId = customerId};
            return Ok(await _getDepositLimitHandler.Handle(request));
        }

        [HttpPut]
        [Route(ResourceNames.DepositLimit)]
        public async Task<IHttpActionResult> Set([FromUri]string customerId, Application.SetDepositLimit.Request request)
        {
            await _setDepositLimitHandler.Handle(request);
            return Ok();
        }

        [HttpDelete]
        [Route(ResourceNames.DepositLimit)]
        public async Task<IHttpActionResult> Disable([FromUri]string customerId, Application.DisableDepositLimit.Request request)
        {
            await _disableDepositLimitHandler.Handle(request);
            return Ok();
        }
    }
}
