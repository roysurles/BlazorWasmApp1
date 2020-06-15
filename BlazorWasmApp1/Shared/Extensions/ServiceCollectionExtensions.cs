using BlazorWasmApp1.Shared.Constants;
using BlazorWasmApp1.Shared.Models.Common.ApiResult;
using BlazorWasmApp1.Shared.Models.Settings;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasmApp1.Shared.Extensions
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
            // https://stackoverflow.com/questions/38515965/cannot-set-configuration-from-json-appsettings-file-in-net-core-project
            //services.Configure<JwtSettingsModel>(configuration.GetSection(AppSettingSectionNames.JwtSettings));
            services.Configure<CorrelationIdSettingsModel>(configuration.GetSection(AppSettingSectionNameConstants.CorrelationIdSettings));
            //services.Configure<SendGridSettingsModel>(configuration.GetSection(AppSettingSectionNames.SendGridSettings));

            // Framework objects
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
            //services.AddApiVersioning();
            //services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            //services.AddMvcCore(config => config.Filters.Add(typeof(GlobalModelStateValidationFilter)))
            //    .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }
    }
}