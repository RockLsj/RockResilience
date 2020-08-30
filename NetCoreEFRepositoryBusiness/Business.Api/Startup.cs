using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Business.EntityFrameworkCore.UnitOfWorks;
using Business.EntityFrameworkCore;
using Business.EntityFrameworkCore.Repositories;
using System.Reflection;
using System.IO;
using System;
using Microsoft.OpenApi.Models;

namespace Business.Api
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
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "直通率API",
                    //TermsOfService = new Uri(""),
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "WT",
                    //    Email = string.Empty,
                    //    Url = new Uri(""),
                    //},
                    //License = new OpenApiLicense
                    //{
                    //    Name = "",
                    //    Url = new Uri(""),
                    //}
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<RockResilienceContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Business.Api")));
            //typeof(ApplicationContext).Assembly.FullName)

            #region Repositories

            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IRockResilienceDbContext, RockResilienceContext>();

            //test
            services.AddTransient<IDeveloperRepository, DeveloperRepository>();
            services.AddTransient<IPeopleTestsRepository, PeopleTestsRepository>();
            services.AddTransient<IConsumeDetailTestsRepository, ConsumeDetailTestsRepository>();
            services.AddTransient<IStudentTest2Repository, StudentTest2Repository>();
            services.AddTransient<IStudentTest3Repository, StudentTest3Repository>();

            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            #region Swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Business.Api");
            });
            #endregion
        }
    }
}
