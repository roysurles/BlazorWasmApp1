
using BlazorWasmApp1.Shared.Models.Common.ApiResult;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasmApp1.Server.Core.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// AddServicesEx
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public static void AddServicesEx(this IServiceCollection services, IConfiguration configuration)
        {
            // Strong typed models for appSettings.json
            services.AddOptions();
            //services.Configure<JwtSettingsModel>(configuration.GetSection(AppSettingSectionNames.JwtSettings));
            //services.Configure<CorrelationIdSettingsModel>(configuration.GetSection(AppSettingSectionNames.CorrelationIdSettings));
            //services.Configure<SendGridSettingsModel>(configuration.GetSection(AppSettingSectionNames.SendGridSettings));

            // Framework objects
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddHttpClient("DefaultHttpClient");

            // Models
            services.AddTransient(typeof(IApiResultModel<>), typeof(ApiResultModel<>));
            services.AddTransient(typeof(ActionResult<>), typeof(ActionResult<>));

            // Metadata

            // DbContexts

            // Repositories

            // Services

            // Add framework services.
            //services.AddCors();
            //services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            //services.AddApiVersioning();
            //services.AddMvc(config => config.Filters.Add(typeof(GlobalModelStateValidationFilter)))
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}