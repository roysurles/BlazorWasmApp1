using System;
using System.Net.Http;
using System.Threading.Tasks;

using BlazorWasmApp1.Client.Features.ParentChild;
using BlazorWasmApp1.Client.Shared;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasmApp1.Client
{
    public static class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "<Pending>")]
        public static Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("BlazorWasmApp1.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorWasmApp1.ServerAPI"));

            builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
            builder.Services.AddHttpClient("BlazorWasmApp1.CoreAPI", client => client.BaseAddress = new Uri("https://localhost:44390/"))
                .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorWasmApp1.CoreAPI"));
            builder.Services.AddTransient((sp => new BlazorWasmApp1CoreApiClient(sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorWasmApp1.CoreAPI"))));

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<HttpContextAccessor>();

            builder.Services.AddTransient<IParentChildService, ParentChildService>();
            builder.Services.AddTransient<IParentChildViewModel, ParentChildViewModel>();

            // example of policy:  https://docs.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-3.1
            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("SuperUser", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(c => c.Value.Equals("Admin")
                    && context.User.HasClaim(c => c.Value.Equals("User"))
                    )));
            });

            builder.Services.AddApiAuthorization()
                .AddAccountClaimsPrincipalFactory<CustomUserFactory>();

            // Example of in-memory Session.Id or TraceId
            builder.Services.AddScoped<SessionSate>();

            return builder.Build().RunAsync();
        }
    }


    // https://docs.microsoft.com/en-us/aspnet/core/security/blazor/webassembly/additional-scenarios?view=aspnetcore-3.1
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager)
            : base(provider, navigationManager)
        {
            ConfigureHandler(
                authorizedUrls: new[] { "https://localhost:44390/" });
        }
    }


    // https://docs.microsoft.com/en-us/aspnet/core/security/blazor/webassembly/additional-scenarios?view=aspnetcore-3.1
    public class BlazorWasmApp1CoreApiClient
    {
        public HttpClient HttpClient { get; }

        public BlazorWasmApp1CoreApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }


        // could strong type it further with
        // https://elanderson.net/2018/03/refit-basics/
        // https://www.hanselman.com/blog/UsingASPNETCore21sHttpClientFactoryWithRefitsRESTLibrary.aspx
        // https://github.com/reactiveui/refit
        // https://code-maze.com/different-ways-consume-restful-api-csharp/
        //public async Task<WeatherForecast[]> GetForecastAsync()
        //{
        //    var forecasts = new WeatherForecast[0];

        //    try
        //    {
        //        forecasts = await client.GetFromJsonAsync<WeatherForecast[]>(
        //            "WeatherForecast");
        //    }
        //    catch (AccessTokenNotAvailableException exception)
        //    {
        //        exception.Redirect();
        //    }

        //    return forecasts;
        //}
    }

}
