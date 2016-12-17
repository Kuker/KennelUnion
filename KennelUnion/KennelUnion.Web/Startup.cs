using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KennelUnion.Data;
using KennelUnion.Data.Entities;
using KennelUnion.Data.Migrations;
using KennelUnion.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KennelUnion.Web
{
    public class Startup
    {
        private IConfigurationRoot _config;
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .SetBasePath(_env.ContentRootPath)
                .AddInMemoryCollection();
            ;
            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(_config);
            services.AddDbContext<DatabaseContext>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();


            services.AddScoped<IRepository<News>, NewsRepository>();
            services.AddScoped<IRepository<About>, AboutRepository>();
            services.AddScoped<IRepository<DogRegistry>, DogRegistryRepository>();
            services.AddTransient<Seed>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, Seed seeder)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseIdentity();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new {controller = "News", action = "Index"}
                );
            });

            seeder.PopulateDb();
        }
    }
}
