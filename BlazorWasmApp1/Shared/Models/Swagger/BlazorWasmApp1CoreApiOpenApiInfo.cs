using System;

using Microsoft.OpenApi.Models;

namespace BlazorWasmApp1.Shared.Models.Swagger
{
    public class BlazorWasmApp1CoreApiOpenApiInfo : OpenApiInfo
    {
        public BlazorWasmApp1CoreApiOpenApiInfo()
        {
            Version = "v1";
            Title = "BlazorWasmApp1 Core API";
            Description = "A simple example ASP.NET Core Web API";
            TermsOfService = new Uri("https://example.com/terms");
            Contact = new OpenApiContact
            {
                Name = "First Last",
                Email = string.Empty,
                Url = new Uri("https://twitter.com/name"),
            };
            License = new OpenApiLicense
            {
                Name = "Use under LICX",
                Url = new Uri("https://example.com/license"),
            };
        }
    }
}
