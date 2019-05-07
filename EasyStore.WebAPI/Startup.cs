using System.Reflection;
using AutoMapper;
using EasyStore.Application.Infrastructure;
using EasyStore.Application.Infrastructure.AutoMapper;
using EasyStore.Application.Interfaces;
using EasyStore.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyStore.WebAPI
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
            //Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            //Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            //Add DbContext
            services.AddDbContext<IEasyStoreDbContext, EasyStoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EasyStoreDb")));



            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                    //.AddFluentValidation(fv =>
                    //{
                        //fv.RegisterValidatorsFromAssemblyContaining<>();
                    //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
