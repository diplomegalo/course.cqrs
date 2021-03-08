using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delsoft.Course.CQRS.Data;
using Delsoft.Course.CQRS.Domain.Commands;
using Delsoft.Course.CQRS.Domain.Commands.Handlers;
using Delsoft.Course.CQRS.Domain.Services;
using Delsoft.Course.CQRS.Model.Commands;
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

namespace Delsoft.Course.CQRS.Web
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
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Delsoft.Course.CQRS.Web", Version = "v1" }); });

            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<ICommandHandler<RegisterWine>, RegisterWineHandler>();
            services.AddScoped<IWineRepository, WineRepository>();

            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("Wine"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Delsoft.Course.CQRS.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}