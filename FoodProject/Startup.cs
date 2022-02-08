using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies; // ekledik
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace FoodProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Login/Index";  // kisi sisteme authentica olmadýysa url olustuurp oraya gonderir
            });

            services.AddMvc(config =>
           {
               var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();     // yetkilendirme politika olusturucu,requ olan sisteme yetkin kullanýcý gerekli        
               config.Filters.Add(new AuthorizeFilter(policy));
           }); // authorize ý controller seviyesine cýkarýr yani projede butun actionresult ve controllerlar authorize

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication(); // ekle!!!!!! login icin

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Category}/{action=Index}/{id?}");                 // URL DE ÝLK SLAÞICONTROLLER SONRAKÝ SLAÞI ACTÝON OLRAK AL
            });

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Merhaba Dünya!");
            //    });
            //});
        }
    }
}
