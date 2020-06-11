
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlazorWasmApp1.Server.Core.Extensions
{
    /// <summary>
    /// RequestServicesExtensions
    /// </summary>
    public static class RequestServicesExtensions
    {
        /// <summary>
        /// GetRequiredService
        /// </summary>
        /// <typeparam name="T">Type of desired service.</typeparam>
        /// <param name="controller">ControllerBase</param>
        /// <returns></returns>
        public static T GetRequiredService<T>(this ControllerBase controller) =>
            controller.GetRequiredService<T>();

        /// <summary>
        /// GetRequiredService
        /// </summary>
        /// <typeparam name="T">Type of desired service.</typeparam>
        /// <param name="httpContext">HttpContext</param>
        /// <returns></returns>
        public static T GetRequiredService<T>(this HttpContext httpContext) =>
            httpContext.GetRequiredService<T>();

        /// <summary>
        /// GetRequiredService
        /// </summary>
        /// <typeparam name="T">Type of desired service.</typeparam>
        /// <param name="actionExecutingContext">ActionExecutingContext</param>
        /// <returns></returns>
        public static T GetRequiredService<T>(this ActionExecutingContext actionExecutingContext) =>
            actionExecutingContext.GetRequiredService<T>();
    }
}
