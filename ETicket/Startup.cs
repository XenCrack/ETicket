using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Data.Services.Concrete;
using ETicket.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket
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
            //DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("default")));

            //bir kez oluþturur ve hafýza atar, tekrar oluþturulmak istenirse
            //ilgili instance hafýzadan çekilir
            //services.AddSingleton<ICinemaService, CinemaService>();

            //gelen her bir istek için bir instance oluþturulur
            //ve gelen her isteðe ayný instance verilir
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IProdcuterService, ProducterService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IMovieTypeService, MovieTypeService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //authentication ve authorization
            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthentication(options =>
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme
            );

            services.AddControllersWithViews();
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
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}/{id?}");
            });

            //seed database
            //ApplicationDbInitializer.Seed(app);
            //ApplicationDbInitializer.SeedUsersAndRolesAsync(app).Wait();

        }
    }
}
