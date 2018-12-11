using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Web_ProjetoCarfel
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();//adiciona mvc
            services.AddSession(//obsoleto , adiciona limite de seção
                options => options.IdleTimeout = TimeSpan.FromMinutes(30)
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();//usa ssssssssss
            app.UseStaticFiles();//permite usar arquivos externos (css/images entre outras bostas)
            
            app.UseMvc(
                routes => routes.MapRoute(
                    name: "default",
                    template:"{controller=Usuario}/{action=PaginaInicial}"
                )
            );
            
        }
    }
}
