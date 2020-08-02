
using BlazorWasmApp1.Shared.Controllers;
using BlazorWasmApp1.Shared.Models.Common.ApiResult;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmApp1.Core.Api.Features.FeatureOne
{
    [AllowAnonymous]
    [ApiVersion("1")]
    [ControllerName("FeatureOne")]
    [Route("api/v{version:apiVersion}/FeaureOne")]
    public class FeatureOneV1Controller : BaseApiController
    {
        [HttpGet]
        [Route("")]
        public ActionResult<IApiResultModel<string>> Get() =>
            CreateActionResult("Hello");
    }
}
