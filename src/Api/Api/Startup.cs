using System;
using System.Reflection;
using System.Text.Json.Serialization;
using API.Infrastructure.AutofacModules;
using API.Infrastructure.Filters;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Basket.Infrastructure;
using Menu.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ordering.Infrastructure;
using AssemblyExtensions = Shared.Infrastructure.AssemblyExtensions;

#pragma warning disable 1591

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc()
                .AddCustomDbContext(Configuration)
                .AddCustomSwagger(Configuration)
                .AddAutoMapper(AssemblyExtensions.GetSolutionAssemblies());

            var autofacContainerBuilder = new ContainerBuilder();
            autofacContainerBuilder.Populate(services);

            autofacContainerBuilder.RegisterModule<MediatorModule>();
            autofacContainerBuilder.RegisterModule(new ApplicationModule(Configuration));

            return new AutofacServiceProvider(autofacContainerBuilder.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DDD Pizza API");
                });

            var swaggerRewriteOptions = new RewriteOptions();
            swaggerRewriteOptions.AddRedirect("^$", "swagger");
            app.UseRewriter(swaggerRewriteOptions);

            app.UseRouting();

            app.UseEndpoints(c => { c.MapControllers(); });
        }
    }

    internal static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddMvc( options => { options.Filters.Add(typeof(GlobalExceptionFilter)); })
                .AddControllersAsServices()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<MenuDbContext>(options =>
                    {
                        options
                            .UseSqlServer(configuration.GetConnectionString("SqlServer"),
                                sqlOptions =>
                                {
                                    sqlOptions.MigrationsAssembly(typeof(MenuDbContext).GetTypeInfo().Assembly.GetName()
                                        .Name);
                                    sqlOptions.MigrationsHistoryTable("__EFMigrationHistory", "Menu");
                                });
                    }
                )
                .AddDbContext<BasketDbContext>(options =>
                {
                    options
                        .UseSqlServer(configuration.GetConnectionString("SqlServer"),
                            sqlOptions =>
                            {
                                sqlOptions.MigrationsAssembly(typeof(BasketDbContext).GetTypeInfo().Assembly.GetName()
                                    .Name);
                                sqlOptions.MigrationsHistoryTable("__EFMigrationHistory", "Basket");
                            });
                })
                .AddDbContext<OrderingDbContext>(options =>
                {
                    options
                        .UseSqlServer(configuration.GetConnectionString("SqlServer"),
                            sqlOptions =>
                            {
                                sqlOptions.MigrationsAssembly(typeof(OrderingDbContext).GetTypeInfo().Assembly.GetName()
                                    .Name);
                                sqlOptions.MigrationsHistoryTable("__EFMigrationHistory", "Ordering");
                            });
                });

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DomainDrivenPizza API",
                    Version = "v1",
                    Description = "The DomainDrivenPizza API"
                });
                options.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            });

            return services;
        }
    }
}
