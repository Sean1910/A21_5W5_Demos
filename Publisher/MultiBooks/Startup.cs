using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultiBooks_DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiBooks_DataAccess.Repositoy;
using MultiBooks_DataAccess.Repositoy.IRepository;
using Microsoft.AspNetCore.Identity;

namespace MultiBooks
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
      services.AddDbContext<MultiBooksDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")
                   ));

      // Injecter le service pour Identity
      services.AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<MultiBooksDbContext>();

      services.AddScoped<IUnitOfWork, UnitOfWork>();

      services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      // Mettre l'authentification AVANT l'authorization
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        // Ajouter le routing pour les pages Razor d'Identity
        endpoints.MapRazorPages();
        endpoints.MapControllerRoute(
                    name: "Customer",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        endpoints.MapControllerRoute(
                   name: "Admin",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        endpoints.MapControllerRoute(
                  name: "Author",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
