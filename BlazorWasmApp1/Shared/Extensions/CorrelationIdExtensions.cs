using System;

using BlazorWasmApp1.Shared.Middleware;
using BlazorWasmApp1.Shared.Models.Settings;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace BlazorWasmApp1.Shared.Extensions
{
    /// <summary>
    /// CorrelationId Extensions
    /// </summary>
    public static class CorrelationIdExtensions
    {
        /// <summary>
        /// UseCorrelationId
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <returns>IApplicationBuilder</returns>
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<CorrelationIdMiddleware>();
        }

        /// <summary>
        /// UseCorrelationId
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="header">string</param>
        /// <returns>IApplicationBuilder</returns>
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app, string header)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseCorrelationId(new CorrelationIdSettingsModel { Header = header });
        }

        /// <summary>
        /// UseCorrelationId
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="options">CorrelationIdSettingsModel</param>
        /// <returns>IApplicationBuilder</returns>
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app, CorrelationIdSettingsModel options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return app.UseMiddleware<CorrelationIdMiddleware>(Options.Create(options));
        }
    }
}
