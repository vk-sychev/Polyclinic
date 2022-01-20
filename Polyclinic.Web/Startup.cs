using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polyclinic.BLL.Implementation;
using Polyclinic.BLL.Interfaces;
using Polyclinic.DAL.Implementation.EF;
using Polyclinic.DAL.Implementation.Repositories;
using Polyclinic.DAL.Interfaces;
using Polyclinic.Web.Mapping;
using Polyclinic.Web.Models;
using Polyclinic.Web.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic
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
            services.AddDbContext<PolyclinicContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PolyclinicConnection")));
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IDoctorRepository, DoctorRepositry>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IVisitService, VisitService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();

            services.AddScoped<IValidator<VisitViewModel>, VisitViewModelValidator>();
            services.AddScoped<IValidator<UserViewModel>, UserViewModelValidator>();
            services.AddScoped<IValidator<DoctorViewModel>, DoctorViewModelValidator>();
            services.AddScoped<IValidator<PatientViewModel>, PatientViewModelValidator>();

            services.AddControllersWithViews()
                .AddFluentValidation(options => options.ImplicitlyValidateChildProperties = true);

            ValidatorOptions.Global.LanguageManager.Enabled = false;
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
