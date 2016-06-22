using System.Threading.Tasks;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.RequestHandlers;
using Pinnacle.ResponsibleGaming.Api.Constants;

namespace Pinnacle.ResponsibleGaming.Api.Controllers
{
    public  class DepositLimitController : ApiController
    {
        private readonly GetDepositLimitHandler _getDepositLimitHandler;
        private readonly SetDepositLimitHandler _setDepositLimitHandler;

        public DepositLimitController(
            GetDepositLimitHandler getDepositLimitHandler,
            SetDepositLimitHandler setDepositLimitHandler
            )
        {
            _getDepositLimitHandler = getDepositLimitHandler;
            _setDepositLimitHandler = setDepositLimitHandler;
        }

        [HttpGet]
        [Route(ResourceNames.DepositLimit)]
        public async Task<IHttpActionResult> Get(string customerId)
        {
            var request = new GetDepositLimit {CustomerId = customerId};
            var getDepositLimitResponse = await _getDepositLimitHandler.Handle(request);
            if (getDepositLimitResponse == null) return NotFound();
            return Ok(getDepositLimitResponse);
        }

        [HttpPut]
        [Route(ResourceNames.DepositLimit)]
        public async Task<IHttpActionResult> Set([FromUri]string customerId, SetDepositLimit request)
        {
            await _setDepositLimitHandler.Handle(request);
            return Ok();
        }
    }
}
