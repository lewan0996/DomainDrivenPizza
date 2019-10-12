using System;
using System.Reflection;
using Api.AutofacModules;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Infrastructure.Basket;
using Infrastructure.Menu;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
#pragma warning disable 1591

namespace Api
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
                .AddAutoMapper(Assembly.GetExecutingAssembly());

            var autofacContainerBuilder = new ContainerBuilder();
            autofacContainerBuilder.Populate(services);

            autofacContainerBuilder.RegisterModule<MediatorModule>();
            autofacContainerBuilder.RegisterModule<ApplicationModule>();

            return new AutofacServiceProvider(autofacContainerBuilder.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "KIM API V1");
                });

            var swaggerRewriteOptions = new RewriteOptions();
            swaggerRewriteOptions.AddRedirect("^$", "swagger");
            app.UseRewriter(swaggerRewriteOptions);

            app.UseMvc();
        }
    }

    internal static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddMvc( /*options => { options.Filters.AddAsync(typeof(HttpGlobalExceptionFilter)); }*/)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddControllersAsServices()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
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
                        options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                            sqlOptions =>
                            {
                                sqlOptions.MigrationsAssembly(typeof(MenuDbContext).GetTypeInfo().Assembly.GetName()
                                    .Name);
                            });
                    }
                )
                .AddDbContext<BasketDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(BasketDbContext).GetTypeInfo().Assembly.GetName()
                                .Name);
                        });
                });

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "DomainDrivenPizza API",
                    Version = "v1",
                    Description = "The DomainDrivenPizza API",
                    TermsOfService = "Terms Of Service"
                });
                options.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            });

            return services;
        }
    }
}
