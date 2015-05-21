using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using VoteApp.Queries;
using VoteApp.Commands; 

namespace VoteApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.ConfigureMvc(options => 
            {
                var formatter = options.OutputFormatters.First(f => f.Instance is JsonOutputFormatter).Instance as JsonOutputFormatter;
                formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();

            services.RegisterQueries();
            services.RegisterCommands();
            services.AddEntityFramework()
                .AddInMemoryStore()
                .AddDbContext<DAL.ApplicationDbContext>();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole(minLevel: LogLevel.Warning);

            if (env.IsEnvironment("Development"))
            {
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }

            // Configure the HTTP request pipeline.
            app.UseFileServer();

            // Add MVC to the request pipeline.
            app.UseMvc();

            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
        }
    }
}
