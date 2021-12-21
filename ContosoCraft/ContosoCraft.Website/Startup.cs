using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ContosoCraft.Website.Models;
using ContosoCraft.Website.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoCraft.Website
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
            services.AddRazorPages();
            services.AddTransient<JsonFileProductService>();   // Told Asp.net about the new Servicen which was created
            services.AddControllers(); // (a) For Controllers
        }

        /*ASP.NET Core uses dependency injection as a fundamental feature to manage dependencies throughout the framework.
        In order for the dependency injection framework to know how to resolve dependencies,
        these dependencies or “services” need to be configured first.

        ASP.NET Core does this already for the very core services when you create the web host in your Program.cs
        but as you enable more features in your web application, you will need to add additional services to the application to opt into functionality.

        For example services.AddMvc() adds the services required to enable the MVC functionality
        and middleware in the application. Or services.AddAuthentication() adds the services
        that are required to enable authentication in your application.
        */


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>   // The Defaut Implementation
            {
                endpoints.MapRazorPages();  // Works for Razor Pages
                endpoints.MapControllers();  // (b) For Controllers

                //endpoints.MapGet("/products", (context) =>
                //{
                //    var products = app.ApplicationServices.GetService<JsonFileProductService>().GetProducts();
                //    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
                //    return context.Response.WriteAsync(json);
                //});
            });

        }
    }
}
