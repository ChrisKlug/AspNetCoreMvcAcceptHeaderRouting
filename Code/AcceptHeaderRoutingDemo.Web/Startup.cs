using AcceptHeaderRoutingDemo.Web.Data;
using AcceptHeaderRoutingDemo.Web.OutputFormatting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace AcceptHeaderRoutingDemo.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config => {
                config.RespectBrowserAcceptHeader = true;
                config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });
            services.AddSingleton<OutputFormatterSelector, AcceptHeaderOutputFormatterSelector>();

            services.AddSingleton<IUsers, Users>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
