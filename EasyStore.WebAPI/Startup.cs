using System.Reflection;
using AutoMapper;
using EasyStore.Application.Infrastructure;
using EasyStore.Application.Infrastructure.AutoMapper;
using EasyStore.Application.Interfaces;
using EasyStore.Application.Products.Queries;
using EasyStore.Infrastructure.Logging;
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

            // Add Framework Services
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));


            //Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetProductsListQueryHandler).GetTypeInfo().Assembly);

            //Add DbContext
            services.AddDbContext<IEasyStoreDbContext, EasyStoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EasyStoreDb")));



            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //.AddFluentValidation(fv =>
            //{
            //fv.RegisterValidatorsFromAssemblyContaining<>();
            //});

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1.0";
                    document.Info.Title = "EasyStore API";
                    document.Info.Description = "A Simple E-Commerce Store API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Easy Store",
                        Email = string.Empty,
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "Licence to WebOnMaster",
                        Url = "http://webonmaster.com"
                    };

                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUi3();
            app.UseMvc();
        }
    }
}
