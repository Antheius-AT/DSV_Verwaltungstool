using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSV_BackEnd_DataLayer;
using DSV_Backend_ServiceLayer;
using DSV_BackEnd_ServicesContracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharedDefinitions.Services;

namespace DSV_BackEnd
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
            services.AddDbContext<DSVDatabaseContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("DSV_DEV_DATABASE"));
            });

            services.AddTransient<IDatabaseService, SQLServerDatabaseService>();
            services.AddTransient<IObjectSerializationService, JSONSerializationService>();
            services.AddTransient<IAuthenticationService, JWTAuthenticationService>();
            services.AddTransient<IObjectMappingService, ModelToDTOMappingService>();

            services.AddSingleton<IAuthenticationTokenStore, DictionaryTokenStore>();

            services.AddLogging();
            services.AddSwaggerGen();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "DSV API V1.0");
                options.RoutePrefix = string.Empty;
            });

            app.UseCors();
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
