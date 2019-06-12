using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FaceTestServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Map("/sync",Sync);

            
            


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });
        }

        private static void Sync(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("currenttime", DateTime.Now.Ticks.ToString());
                dic.Add("version", "100");
                dic.Add("lastupdate", new DateTime(2001, 6, 6).Ticks.ToString());

                await context.Response.WriteAsync(XML.ParamsToXml(dic).ToString());
            });
        }

    }
}
