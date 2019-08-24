using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.BusinessLogic.LogicHandler;
using BL.BusinessLogic.ViewModel.Mapping;
using DAL.Data;
using DAL.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SL.API.Common;

namespace SL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Server=localhost;Initial Catalog=dndSpell;Persist Security Info=False;User ID=dnd;Password=dnd2019;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
            services.AddDbContext<DndSpellContext>(options => options
            .UseSqlServer(connectionString, b => { b.MigrationsAssembly("SL.API"); b.EnableRetryOnFailure(); })
            .ConfigureWarnings(w => w.Throw(CoreEventId.IncludeIgnoredWarning)));
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.AddScoped<IResponseFormatter, ResponseFormatter>();
            services.AddScoped<IRequestHandler, RequestHandler>();
            services.AddScoped<DndRepository>();
            services.AddScoped<SpellLogicHandler>();
            AutoMapperConfiguration.Configure();
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
