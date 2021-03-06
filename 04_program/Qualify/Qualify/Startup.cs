using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Qualify.Repository;
using Qualify.Service;

namespace Qualify
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection service)
        {            
            Configuration.Bind("Project", new Config());
            service.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
            service.AddDbContext<QualifyContext>(options => options.UseSqlServer(Config.ConnectionString));
#if DEBUG
            service.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            service.AddScoped<ClaimRepository, ClaimRepository>();
            service.AddScoped<ClientRepository, ClientRepository>();
            service.AddScoped<ClaimHistoryRepository, ClaimHistoryRepository>();
            service.AddScoped<EmployeeRepository, EmployeeRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute("Claim", "{controller=Claim}/{action=ViewAllClaims}/{id?}");
            });
        }
    }
}
