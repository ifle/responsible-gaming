﻿using System.Threading.Tasks;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Handlers;
using Pinnacle.ResponsibleGaming.Api.Constants;

namespace Pinnacle.ResponsibleGaming.Api.Controllers
{
    public  class DepositLimitController : ApiController
    {
        private readonly GetDepositLimitHandler _getDepositLimitHandler;
        private readonly SetDepositLimitHandler _setDepositLimitHandler;
        private readonly DisableDepositLimitHandler _disableDepositLimitHandler;

        public DepositLimitController(
            GetDepositLimitHandler getDepositLimitHandler,
            SetDepositLimitHandler setDepositLimitHandler,
            DisableDepositLimitHandler disableDepositLimitHandler
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
            var request = new GetDepositLimit {CustomerId = customerId};
            return Ok(await _getDepositLimitHandler.Handle(request));
        }

        [HttpPut]
        [Route(ResourceNames.DepositLimit)]
        public async Task<IHttpActionResult> Set([FromUri]string customerId, SetDepositLimit request)
        {
            await _setDepositLimitHandler.Handle(request);
            return Ok();
        }

        [HttpDelete]
        [Route(ResourceNames.DepositLimit)]
        public async Task<IHttpActionResult> Disable([FromUri]string customerId, DisableDepositLimit request)
        {
            await _disableDepositLimitHandler.Handle(request);
            return Ok();
        }
    }
}
