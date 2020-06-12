
using BlazorWasmApp1.Core.Api.Data;
using BlazorWasmApp1.Core.Api.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorWasmApp1.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.1
            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("https://localhost:44350");
            }
            ));

            services.AddIdentityServer()
                 .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                 {
                     options.Clients.AddSPA(
                         "BlazorWasmApp1.Client", spa =>
                         spa.WithRedirectUri("http://localhost:44350/authentication/login-callback")
                            .WithLogoutRedirectUri(
                                "http://localhost:44350/authentication/logout-callback"));

                     options.ApiResources.AddApiResource("MyExternalApi", resource =>
                         resource.WithScopes("a", "b", "c"));
                 });

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            //app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
