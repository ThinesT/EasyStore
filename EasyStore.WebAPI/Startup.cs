using System.Reflection;
using AutoMapper;
using EasyStore.Application.Infrastructure;
using EasyStore.Application.Infrastructure.AutoMapper;
using EasyStore.Application.Interfaces;
using EasyStore.Application.Products.Queries;
using EasyStore.Infrastructure.Logging;
using EasyStore.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using EasyStore.Application.Products.Commands.CreateProduct;
using EasyStore.Infrastructure.Notification;
using EasyStore.WebAPI.Filters;
using EasyStore.Application.Products.Queries.GetProductsList;
using ElmahCore.Mvc;

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
            services.AddTransient<INotificationService, NotificationService>();


            //Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetProductsListQueryHandler).GetTypeInfo().Assembly);

            //Add DbContext
            services.AddDbContext<IEasyStoreDbContext, EasyStoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EasyStoreDb")));

            //Add Logging UI Service - ElmahCore
            services.AddElmah();

            services.AddMvc(options => {
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
              .AddFluentValidation(fv =>
                 {
                     fv.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
                 });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //Add Swagger
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
                        Name = "Licence to Thines T",
                        Url = "http://webonmaster.com"
                    };

                };
            });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.SubstituteApiVersionInUrl = true;
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
            app.UseElmah();
            app.UseMvc();
        }
    }
}
