using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CourtTennisBookingv2BE.Models;

namespace CourtTennisBookingv2BE
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

            services.AddControllers();
  
            services.AddMvc();
            var ConnectionString = Configuration.GetConnectionString("MbkDbConstr");
            
            services.AddDbContext<TennisBooking_v1Context>(options => options.UseSqlServer(ConnectionString));


            services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo
                  {
                      Version = "v1",
                      Title = "Court Tennis Booking ",
                      Description = "Court Tennis Booking Core Web API ",
                      TermsOfService = new Uri("https://example.com/terms"),
                      Contact = new OpenApiContact
                      {
                          Name = "",
                          Url = new Uri("https://example.com/contact")
                      },
                      License = new OpenApiLicense
                      {
                          Name = "",
                          Url = new Uri("https://example.com/license")
                      }
                  });
              });
        }









              

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options => options.WithOrigins("http://localhost:3000", "http://http://traveltogetherr.somee.com", "http://localhost:3001").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            if (env.IsDevelopment() || env.IsProduction()) //env isproduction la ban public, dev la chay local
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CourtTennisBookingv2BE v1"));
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
