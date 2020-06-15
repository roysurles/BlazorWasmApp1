using System;

using BlazorWasmApp1.Shared.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmApp1.Core.Api.Controllers
{
    [AllowAnonymous]
    [ApiVersion("1")]
    [ControllerName("Error")]
    [Route("api/v{version:apiVersion}/Error")]
    public class ErrorV1Controller : BaseApiController
    {
        [HttpGet]
        [Route("")]
        public ActionResult ThrowException()
        {
            throw new UnauthorizedAccessException();
        }
    }
}
