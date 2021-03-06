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
using OfficePrinterAssistant.DataAccess;
using Microsoft.EntityFrameworkCore;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.ApplicationServices.API.Mappings;
using OfficePrinterAssistant.DataAccess.CQRS;
using FluentValidation.AspNetCore;
using OfficePrinterAssistant.ApplicationServices.API.Validators;
using OfficePrinterAssistant.ApplicationServices.Components.OpenWeather;
using Microsoft.AspNetCore.Authentication;
using OfficePrinterAssistant.Authentication;

namespace OfficePrinterAssistant
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
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddMvcCore().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddPrinterRequestValidator>());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<IWeatherConnector, WeatherConnector>();
            services.AddAutoMapper(typeof(PrinterProfile).Assembly);
            services.AddMediatR(typeof(ResponseBase<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<PrinterAssistantDbContext>(
                opt => opt.UseSqlServer(this.Configuration.GetConnectionString("PrinterAssistantDatabaseConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OfficePrinterAssistant", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OfficePrinterAssistant v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
