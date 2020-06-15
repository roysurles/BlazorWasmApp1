//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//using Swashbuckle.AspNetCore.Swagger;
//using Swashbuckle.AspNetCore.SwaggerGen;
//using Swashbuckle.AspNetCore.SwaggerUI;

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Reflection;

//namespace BlazorWasmApp1.Shared.Extensions
//{
//    /// <summary>
//    /// Swagger Extensions
//    /// </summary>
//    public static class SwaggerExtensions
//    {
//        private const string Title = "Cheffor IdentityApi";

//        /// <summary>
//        /// AddSwaggerEx
//        /// </summary>
//        /// <param name="services">IServiceCollection</param>
//        /// <param name="configuration">IConfiguration</param>
//        public static void AddSwaggerEx(this IServiceCollection services, IConfiguration configuration)
//        {
//            // Register the Swagger generator, defining one or more Swagger documents
//            services.AddSwaggerGen(options =>
//            {
//                options.SwaggerDoc("v1", new Info
//                {
//                    Version = "v1",
//                    Title = Title,
//                    Description = "Cheffor IdentityApi Description",
//                    Contact = new Contact
//                    {
//                        Name = "Cheffor Developers",
//                        Email = "cheffor@cheffor.com",
//                        Url = "https://108.175.14.208/Cheffor.IdentityApi/"
//                    }
//                });

//                // Setup JWT Bearer Token
//                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
//                {
//                    In = "header",
//                    Description = "Please insert JWT with Bearer into field",
//                    Name = "Authorization",
//                    Type = "apiKey"
//                });

//                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
//                {
//                    { "Bearer", Array.Empty<string>() }
//                });

//                // This call remove version from parameter, without it we will have version as parameter
//                // for all endpoints in swagger UI
//                options.OperationFilter<RemoveVersionFromParameter>();

//                // This make replacement of v{version:apiVersion} to real version of corresponding swagger doc.
//                options.DocumentFilter<ReplaceVersionWithExactValueInPath>();

//                // Order methods
//                options.DocumentFilter<OrderByFilter>();

//                // This on used to exclude endpoint mapped to not specified in swagger version.
//                // In this particular example we exclude 'GET /api/v2/Values/otherget/three' endpoint,
//                // because it was mapped to v3 with attribute: MapToApiVersion("3")
//                options.DocInclusionPredicate((docName, apiDesc) =>
//                {
//                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

//                    var versions = methodInfo.DeclaringType
//                        .GetCustomAttributes(true)
//                        .OfType<ApiVersionAttribute>()
//                        .SelectMany(attr => attr.Versions);

//                    return versions.Any(v => $"v{v}" == docName);
//                });

//                // Set the comments path for the Swagger JSON and UI.
//                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
//                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//                options.IncludeXmlComments(xmlPath);

//                options.DescribeAllEnumsAsStrings();
//            });
//        }

//        /// <summary>
//        /// UseSwaggerEx
//        /// </summary>
//        /// <param name="app">IApplicationBuilder</param>
//        /// <param name="env">IHostingEnvironment</param>
//        public static void UseSwaggerEx(this IApplicationBuilder app, IHostingEnvironment env)
//        {
//            // Enable middleware to serve generated Swagger as a JSON endpoint.
//            app.UseSwagger();

//            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
//            app.UseSwaggerUI(options =>
//            {
//                options.SwaggerEndpoint("./swagger/v1/swagger.json", "Cheffor IdentityApi V1");
//                options.RoutePrefix = string.Empty;
//                options.DocumentTitle = Title;
//                options.DocExpansion(DocExpansion.None);
//            });
//        }
//    }

//    /// <summary>
//    /// RemoveVersionFromParameter
//    /// </summary>
//    public class RemoveVersionFromParameter : IOperationFilter
//    {
//        /// <summary>
//        /// Apply
//        /// </summary>
//        /// <param name="operation">Operation</param>
//        /// <param name="context">OperationFilterContext</param>
//        public void Apply(Operation operation, OperationFilterContext context)
//        {
//            var versionParameter = operation.Parameters.Single(p => p.Name == "version");
//            operation.Parameters.Remove(versionParameter);
//        }
//    }

//    /// <summary>
//    /// ReplaceVersionWithExactValueInPath
//    /// </summary>
//    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
//    {
//        /// <summary>
//        /// Apply
//        /// </summary>
//        /// <param name="swaggerDoc">SwaggerDocument</param>
//        /// <param name="context">DocumentFilterContext</param>
//        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
//        {
//            swaggerDoc.Paths = swaggerDoc.Paths
//                .ToDictionary(
//                    path => path.Key.Replace("v{version}", swaggerDoc.Info.Version),
//                    path => path.Value
//                );
//        }
//    }

//    /// <summary>
//    /// OrderByFilter
//    /// </summary>
//    public class OrderByFilter : IDocumentFilter
//    {
//        /// <summary>
//        /// Apply
//        /// </summary>
//        /// <param name="swaggerDoc">SwaggerDocument</param>
//        /// <param name="context">DocumentFilterContext</param>
//        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
//        {
//            // make operations alphabetic
//            var paths = swaggerDoc.Paths.OrderBy(e => e.Key).ToList();
//            swaggerDoc.Paths = paths.ToDictionary(e => e.Key, e => e.Value);
//        }
//    }
//}

