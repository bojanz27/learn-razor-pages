using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GermanVocabulary.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GermanVocabulary
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<GermanVocabularyDbContext>(
                    options =>
                        options.UseNpgsql(
                            Configuration.GetConnectionString("DefaultConnection"),
                            x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "public")))
                .BuildServiceProvider();

            services.AddScoped<WordsRepository>();

            services.AddMvc()
                //.AddRazorPagesOptions(
                //opts =>
                //    opts.Conventions
                //    .AddPageRoute("/Vocabulary", "/Words")
                //    .AddPageRoute("/Vocabulary", "")
                //    .AddPageRoute("/Vocabulary/Filter/{lang}", "/Words/Filter/{lang}")
                //)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
