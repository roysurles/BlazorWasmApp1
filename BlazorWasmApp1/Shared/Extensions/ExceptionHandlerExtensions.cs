using System;
using System.Net;

using BlazorWasmApp1.Shared.Models.Common;
using BlazorWasmApp1.Shared.Models.Common.ApiResult;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace BlazorWasmApp1.Shared.Extensions
{
    /// <summary>
    /// ExceptionHandler Extensions
    /// </summary>
    public static class ExceptionHandlerExtensions
    {
        /// <summary>
        /// UseExceptionHandlerEx
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IHostingEnvironment</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "RCS1075:Avoid empty catch clause that catches System.Exception.", Justification = "<Pending>")]
        public static void UseExceptionHandlerEx(this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature?.Error == null)
                        return;

                    var exception = contextFeature.Error;
                    try
                    {
                        // TODO:  Logging
                        //context.RiseError(exception);
                    }
                    catch (Exception)
                    {
                        // suppress any exceptions when attempting RiseError.
                    }

                    var httpStatusCode = HttpStatusCode.InternalServerError;
                    if (exception is UnauthorizedAccessException)
                        httpStatusCode = HttpStatusCode.Unauthorized;

                    var apiResult = context.GetRequiredService<IApiResultModel<string>>().SetHttpStatusCode(httpStatusCode);
                    if (env.IsProduction())
                        apiResult.AddMessage(ApiResultMessageType.Error, "We apologize, but an error occurred while processing this request.", context.Request.Path, httpStatusCode);
                    else
                        apiResult.AddMessage(exception);

                    context.Response.ContentType = ContentType.ApplicationJson.Text;
                    context.Response.StatusCode = (int)httpStatusCode;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(apiResult)).ConfigureAwait(false);
                });
            });
        }
    }
}
