using AdminCategoryService.Entities;
using AdminCategoryService.Extensions;
using AdminCategoryService.Manager;
using AdminCategoryService.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace AdminCategoryService
{

    [ExcludeFromCodeCoverage]
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
            services.AddDbContext<EmartDBContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("connectionstring")));
            services.AddMvc(
              config =>
              {

                  config.Filters.Add(typeof(CustomExceptionFilter));

              }
          );
            services.AddCors(c => {
                c.AddPolicy("AllowOrigin", options =>
                 options.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader()


               );
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdminServices", Version = "v1", Description = "ASP.NET CORE ADMIN SERVICEMODULE",
                    Contact = new OpenApiContact
                    {
                        Name = "4AC-Batch",
                        Email ="Naga.Mediboina@cognizant.com",
                        Url = new Uri("https://github.com/NagaSatish45/ECOMMERCE_AdminServiceModule_Batch_4AC"),
                    },
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory,xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
           



            services.AddDbContext<EmartDBContext>();
            services.AddTransient<IAdminRepository, AdminRepositoty>();
            services.AddTransient<IManager, AdminManager>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureExceptionHandler();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AllowOrigin");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin Services");
            });
        }
    }
}
