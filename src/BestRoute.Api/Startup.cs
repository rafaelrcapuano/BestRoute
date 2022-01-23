using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using BestRoute.Api.Filters;
using BestRoute.Infra.CrossCutting;

namespace BestRoute.Api
{
    public class Startup
    {
        private readonly string _filePath;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _filePath = Configuration["filePath"];
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(opt =>
                {
                    opt.Filters.Add<ExceptionFilter>();
                })
                .AddNewtonsoftJson(opt =>
                 {
                     opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                     opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                     opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                     opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                     opt.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                 });

            services.AddUseCase(_filePath);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
