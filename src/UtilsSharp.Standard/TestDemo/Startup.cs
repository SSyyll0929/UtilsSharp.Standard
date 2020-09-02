using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore;
using AspNetCore.Autofac;
using AspNetCore.Interceptor;
using AspNetCore.Swagger;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestDemo
{
    public class Startup:AutofacStartup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var docOptions = new SwaggerDocOptions { Name = "v1", OpenApiInfo = { Title = "WeiXinMp", Version = "v1", Description = "��������" }, Enable = true };
            docOptions.HeaderParameters.Add(new HeaderParameter(){Name = "token",Value = "" });
            services.AddAspNetCoreExtensions(docOptions);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //ע����չ
            app.UseAspNetCoreExtensions();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        /// <summary>
        /// ����ע��ӳ��
        /// </summary>
        /// <param name="builder">builder</param>
        public override void ConfigureContainer(ContainerBuilder builder)
        {
            Init<LoggerInterceptor>(builder);
        }
    }
}
