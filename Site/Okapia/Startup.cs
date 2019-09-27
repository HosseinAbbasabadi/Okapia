﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Okapia.Configuration;
using Okapia.Helpers;
using reCAPTCHA.AspNetCore;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace Okapia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var bootstrapper = new Bootstrapper(Configuration);
            bootstrapper.Wireup(services);
            services.AddScoped<ICookieHelper, CookieHelper>();

            services.AddScoped<AuthorizeFilter>();

            services.Configure<CookiePolicyOptions>(options =>
            {
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
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes =
                    ResponseCompressionDefaults.MimeTypes.Concat(
                        new[] {"image/svg+xml/css/js"});
            });
            services.AddResponseCaching();

            services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.CacheProfiles.Add("Default",
                        new CacheProfile
                        {
                            Duration = 60,
                            Location = ResponseCacheLocation.Any
                        });
                })
                .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseResponseCaching();
            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.Expires] =
                        "public,max-age=" + durationInSeconds;
                }
            });
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