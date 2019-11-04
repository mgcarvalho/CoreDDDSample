﻿namespace Core.Application
{
    using Core.Domain.Entity;
    using Core.Domain.Repository;
    using Core.MySQLData;
    using Core.MySQLData.Repositories.Concrete;
    using Core.Services.Service;
    using Core.Services.Service.concrete;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

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
            
            //Context
            //MySQL
            string connectionString = Configuration["ConnectionString:MyConnectionString"];
            services.AddDbContext<CoreContext>(options => options.UseMySql(connectionString));

            //DI
            //Repository
            //MySQL
            services.AddTransient<IRepository<EntityBase>, MySQLRepository<EntityBase>>();
            //Memory
            //services.AddTransient<IRepository<EntityBase>, MemoryRepository<EntityBase>>();
            //MongoDB
            //services.AddTransient<IRepository<EntityBase>, MongoDBRepository<EntityBase>>();

            //Services
            services.AddScoped<IPostService, PostService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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
            app.UseMvc();
        }
    }
}
