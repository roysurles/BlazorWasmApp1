using System;
using System.Threading.Tasks;

using BlazorWasmApp1.Shared.Controllers;
using BlazorWasmApp1.Shared.Models;
using BlazorWasmApp1.Shared.Models.Common.ApiResult;

using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        [Route("throw")]
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
