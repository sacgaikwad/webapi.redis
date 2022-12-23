using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiScopeSample.implementation;
using webapiScopeSample.interfaces;

namespace webapiScopeSample
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
            services.AddControllers();
                       
            services.AddTransient<ITransientService, OperationService>();
            services.AddScoped<IScopedService, OperationService>();
            services.AddSingleton<ISingletonService, OperationService>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "redis-cache-container:6379";
            });

            services.AddScoped<IDatastoreProvider, RedisDatastore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //            app.UseCustomMiddleware();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");

            //    await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
            //    await next();
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Before Invoke from 2nd app.Use()\n");

            //    await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from 1st app.Run()\n");
            //});

            //// the following will never be executed    
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from 2nd app.Run()\n");
            //});

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
