using System.Net;

using BlazorWasmApp1.Shared.Controllers;
using BlazorWasmApp1.Shared.Extensions;
using BlazorWasmApp1.Shared.Models.Common.ApiResult;

using Microsoft.AspNetCore.Mvc.Filters;

namespace BlazorWasmApp1.Shared.Filters
{
    /// <summary>
    /// Global Model State Validation Filter
    /// </summary>
    public sealed class GlobalModelStateValidationFilter : ActionFilterAttribute
    {
        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context">ActionExecutingContext</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            if (modelState?.IsValid != false)
                return;

            var result = context.GetRequiredService<IApiResultModel<object>>()
                .SetHttpStatusCode(HttpStatusCode.BadRequest)
                .AddMessages(modelState);
            context.Result = ((BaseApiController)context.Controller).BadRequest(result);
        }
    }
}
