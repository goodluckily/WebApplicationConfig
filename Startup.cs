using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApplicationConfig
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
            //var builder = new ConfigurationBuilder();
            //builder.AddJsonFile("appsettings.json");
            //var configurationRoot = builder.Build();

            //������ appsettings.json �� AppSettings ��
            services.Configure<ConfigOptionsModel>(Configuration);

            //Ϊѡ���������֤�߼�
            services.AddOptions<ConfigOptionsModel>().Configure(op =>
            {
                Configuration.Bind(op);
            })

            ////����������֤ [Range(1,200)]
            //.ValidateDataAnnotations();


            //�Զ���������֤ ConfigOptionsVaildateOptions
            .Services.AddSingleton<IValidateOptions<ConfigOptionsModel>, ConfigOptionsVaildateOptions>();

            ////�Զ�������
            //.Validate(x =>
            //{
            //    return x.key4 <= 200;
            //}, "key4 ���ܴ���200");

            //��̬���ò���
            services.PostConfigure<ConfigOptionsModel>(option =>
            {
                option.key1 += "===>PostConfigure";
            });

            //services.AddScoped<ConfigOptionsModel>();
            //services.AddSingleton<ConfigOptionsModel>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
