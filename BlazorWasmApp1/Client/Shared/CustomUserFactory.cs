﻿using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

using BlazorWasmApp1.Shared.Models;

using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Microsoft.AspNetCore.Http;

namespace BlazorWasmApp1.Client.Shared
{
    public class CustomUserFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpContextAccessor _httpContextAccessor;

        public CustomUserFactory(IAccessTokenProviderAccessor accessor, IHttpClientFactory clientFactory, HttpContextAccessor httpContextAccessor) : base(accessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Wrong Usage", "DF0010:Marks undisposed local variables.", Justification = "<Pending>")]
        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
        {
            var user = await base.CreateUserAsync(account, options);

            if (user.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)user.Identity;
                var roleClaims = identity.FindAll(identity.RoleClaimType);

                if (roleClaims?.Any() == true)
                {
                    foreach (var existingClaim in roleClaims)
                    {
                        identity.RemoveClaim(existingClaim);
                    }

                    var rolesElem = account.AdditionalProperties[identity.RoleClaimType];

                    if (rolesElem is JsonElement roles)
                    {
                        if (roles.ValueKind == JsonValueKind.Array)
                        {
                            foreach (var role in roles.EnumerateArray())
                            {
                                identity.AddClaim(new Claim(options.RoleClaim, role.GetString()));
                            }
                        }
                        else
                        {
                            identity.AddClaim(new Claim(options.RoleClaim, roles.GetString()));
                        }
                    }
                }

                if (_httpContextAccessor.HttpContext?.TraceIdentifier != null)
                    identity.AddClaim(new Claim("TraceIdentifier", _httpContextAccessor.HttpContext.TraceIdentifier));
                //identity.AddClaim(new Claim("Session.Id", _httpContextAccessor.HttpContext.Session.Id));

                identity.AddClaim(new Claim("MyCustomClaim", "MyCustomClaim.Value"));

                // this is one way to get additional claims...
                var httpClient = _clientFactory.CreateClient("BlazorWasmApp1.ServerAPI");
                var forecasts = await httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
                foreach (var forecast in forecasts)
                    identity.AddClaim(new Claim(forecast.Summary, forecast.Date.ToString()));
            }

            return user;
        }
    }
}
