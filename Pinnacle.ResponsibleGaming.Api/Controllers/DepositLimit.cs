using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Handlers;
using Pinnacle.ResponsibleGaming.Api.Constants;
using Pinnacle.ResponsibleGaming.Api.Links;
using Pinnacle.ResponsibleGaming.Api._Framework;
using Swashbuckle.Swagger.Annotations;

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
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<IHttpActionResult> Get(string customerId)
        {
            // Map request
            var request = new GetDepositLimit {CustomerId = customerId};

            // Handle request
            var response = await _getDepositLimitHandler.Handle(request);

            // Return NotFound if it doesn't exist
            if (response == null) return NotFound();

            // Add HAL links
            response.Links.Add(DepositLimitLinks.Get.CreateLink(new {customerId}));

            // Return response
            return Ok(response);
        }

        [HttpPut]
        [Route(ResourceNames.DepositLimit)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NoContent)]
        public async Task<IHttpActionResult> Set([FromUri]string customerId, [FromBody]SetDepositLimit request)
        {
            // Map request
            request.CustomerId = customerId;

            // Handle request
            await _setDepositLimitHandler.Handle(request);

            // Return success NoContent
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route(ResourceNames.DepositLimit)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NoContent)]
        public async Task<IHttpActionResult> Disable([FromUri]string customerId, [FromBody]DisableDepositLimit request)
        {
            // Map request
            request.CustomerId = customerId;

            // Handle request
            await _disableDepositLimitHandler.Handle(request);

            // Return success NoContent
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
