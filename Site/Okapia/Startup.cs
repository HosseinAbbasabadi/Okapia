using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Okapia.Configuration;
using Okapia.Helpers;
using reCAPTCHA.AspNetCore;

namespace Okapia
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
            var bootstrapper = new Bootstrapper(Configuration);
            bootstrapper.Wireup(services);
            services.AddScoped<AuthorizeFilter>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account/Login");
                    o.LogoutPath = new PathString("/Account/Logout");
                    o.AccessDeniedPath = new PathString("/Account/AccessDenied");
                });

            services.AddHttpContextAccessor();
            services.Configure<RecaptchaSettings>(Configuration.GetSection("RecaptchaSettings"));
            services.AddMvc(options => { options.EnableEndpointRouting = false; })
                .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseMvc(ConfigureRoutes());
        }

        private static Action<IRouteBuilder> ConfigureRoutes()
        {
            return routes =>
            {
                routes.MapRoute(
                    "customer_area",
                    "{area}/{controller}/{action}/{id?}"
                );
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            };
        }
    }
}