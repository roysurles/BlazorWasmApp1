using System;
using System.Threading.Tasks;

using BlazorWasmApp1.Shared.Controllers;
using BlazorWasmApp1.Shared.Models;
using BlazorWasmApp1.Shared.Models.Common.ApiResult;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmApp1.Core.Api.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [ApiVersion("1")]
    [ControllerName("Error")]
    [Route("api/v{version:apiVersion}/Error")]
    public class ErrorV1Controller : BaseApiController
    {

        /// <summary>
        /// Example of global exception handler for webapi.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /throw
        ///
        /// </remarks>
        /// <returns>nothing, throws UnauthorizedAccessException exception</returns>
        /// <response code="500">If the item is null</response>
        [HttpGet]
        [Route("throw")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ActionResult> ThrowException()
        {
            throw new UnauthorizedAccessException();
        }

        [HttpPost]
        [Route("")]
        public ActionResult<IApiResultModel<BadModelStateRequestModel>> BadModelState([FromBody] BadModelStateRequestModel badModelStateRequestModel)
        {
            return CreateActionResult(badModelStateRequestModel);
        }
    }

}
