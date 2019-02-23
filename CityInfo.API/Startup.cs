using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Enities;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace CityInfo.API
{
    public class Startup
    {
        /// <summary>
        /// this is required for Core 1.0
        /// </summary>
        //public static IConfigurationRoot ConfigurationCore1;
        //public Startup(IHostingEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json",optional:true,reloadOnChange:true)
        //           .AddEnvironmentVariables(); // we can add cofiguaration object to gain access to the environment variables as an addtional configuration source
        //    ConfigurationCore1 = builder.Build();
        //}

        /// <summary>
        /// this is required for Core 2.0
        /// </summary>
        public static IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()
                    ));
            //.AddJsonOptions(o=> {
            //    if (o.SerializerSettings.ContractResolver != null)
            //    {
            //        var castedResolver = o.SerializerSettings.ContractResolver
            //              as DefaultContractResolver;
            //        castedResolver.NamingStrategy = null;
            //    }
            // });

            services.AddTransient<IMailServices, LocalMailService>();
            string connectionString= Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<CityInfoContext>(o=>o.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            // loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
            // For Shortcut
            loggerFactory.AddNLog();// Third party logging is integrated with .net core 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseMvc();
            app.UseStatusCodePages();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
