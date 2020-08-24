using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.EntityFrameworkCore;
using Business.EntityFrameworkCore.Repositories;
//using Business.EntityFrameworkCore.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Business.EntityFrameworkCore.UnitOfWorks;
using Business.EntityFrameworkCore.Repositories.Interfaces;

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
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Business.Api")));
            //typeof(ApplicationContext).Assembly.FullName)

            #region Repositories

            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IApplicationDbContext, ApplicationContext>();

            //test
            services.AddTransient<IDeveloperRepository, DeveloperRepository>();
            services.AddTransient<IPeopleTestsRepository, PeopleTestsRepository>();
            services.AddTransient<IConsumeDetailTestsRepository, ConsumeDetailTestsRepository>();
            services.AddTransient<IStudentTest2Repository, StudentTest2Repository>();
            services.AddTransient<IStudentTest3Repository, StudentTest3Repository>();

            services.AddTransient<IC_WORK_DESC_TRepository, C_WORK_DESC_TRepository>();
            services.AddTransient<IWriteNumberRepository, WriteNumberRepository>();
            services.AddTransient<IStationResumeRepository, StationResumeRepository>();
            services.AddTransient<IStationResume_FailRepository, StationResume_FailRepository>();
            services.AddTransient<IR_STATION_REC_TRepository, R_STATION_REC_TRepository>();
            services.AddTransient<IStation_informationRepository, Station_informationRepository>();
            services.AddTransient<IBAH_MOProcessFlowRepository, BAH_MOProcessFlowRepository>();

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
