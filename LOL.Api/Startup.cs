using AutoMapper;
using LOL.Core.Repositories;
using LOL.Core.Repositories.LOLRepositories;
using LOL.Core.UoWs;
using LOL.Domain.Contracts.Services;
using LOL.Domain.Mappers;
using LOL.Domain.Services;
using LOL.Infrastructure.Data;
using LOL.Infrastructure.Repositories;
using LOL.Infrastructure.Repositories.LOLRepositories;
using LOL.Infrastructure.UoWs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LOL.Api
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
            services.AddCors();
            services.AddHttpContextAccessor();

            services.AddDbContext<LOLContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LOLConnection"));
            });

            //services.AddHttpContextAccessor();

            services.AddTransient<ILOLUnitOfWork, LOLUnitOfWork>();
            services.AddTransient<IChempionRepository, ChempionRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IChempionService, ChempionService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ITournamentService, TournamentService>();
            services.AddTransient<IDictionariesService, DictionariesService>();

            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new LOLMappingProfile());
            })
            .CreateMapper()
            );

            services.AddControllersWithViews();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/client-app";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}

            //app.UseExceptionHandler(exceptionHandlerApp => {
            //    exceptionHandlerApp.Run(async context => {
            //        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //        context.Response.ContentType = Text.Plain;

            //        var exceptionHandlerPathFeature =
            //        context.Features.Get<IExceptionHandlerPathFeature>();

            //        var exceptionModel = new ExceptionHandlerModel()
            //        {
            //            Message = exceptionHandlerPathFeature.Error.GetMessages(),
            //            Path = exceptionHandlerPathFeature.Path,
            //            Stack = exceptionHandlerPathFeature.Error.StackTrace
            //        };

            //        await context.Response.WriteAsync(exceptionModel.ToJson());
            //    });
            //});

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
