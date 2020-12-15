using System;
using E_LearningSite.API.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using E_LearningSite.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using E_LearningSite.API.SQLDatabase;

namespace E_LearningSite.API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LearningContext>(
                options => options.UseSqlServer(_config.GetConnectionString("ELearningDbConnection"))
            );

            services.AddCors(options =>
            {
                options.AddPolicy("ReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000");
                    });
            });
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddSingleton<ISchoolRepository, InMemorySchoolDatabase>();
            //services.AddScoped<ISchoolRepository, InSQLSchoolDatabase>();

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "E-LearningSiteOpenAPISpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "E-Learning Site API",
                        Version = "1.3"
                    });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
               .WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/E-LearningSiteOpenAPISpecification/swagger.json", "E-Learning Site API");
                setupAction.RoutePrefix = "";
            });

            app.UseStaticFiles();

            app.UseMvc();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
