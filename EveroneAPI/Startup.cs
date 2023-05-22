using EveroneAPI.Comoon;
using EveroneAPI.ContextDB;
using EveroneAPI.Filter;
using EveroneAPI.jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace JWT
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }
        readonly IWebHostEnvironment env;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "any", set => { set.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials(); }

                    /*"any",*/
                    //builder => builder.AllowAnyOrigin()
                    //.AllowAnyHeader()
                    //.AllowAnyMethod()
                    );
            });
            services.AddControllers();
            services.AddScoped<TokenFilter>();
            services.AddSingleton<IQRCode, RaffQRCode>();
            services.AddSignalR(config =>
            {
                if (env.IsDevelopment())
                {
                    config.EnableDetailedErrors = true;
                }
            });
            #region JWT
            services.AddTransient<ITokenHelper, TokenHelper>();
            services.Configure<JWTConfig>(Configuration.GetSection("JWTConfig"));
            services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
           AddJwtBearer();
            #endregion
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Everone",
                    Description = ""
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.DocInclusionPredicate((docName, description) => true);
                c.CustomSchemaIds(type => type.FullName);
            });
            #endregion
            services.AddDbContext<ContextDBs>(
              opt => opt.UseSqlServer(Configuration.GetConnectionString("sql")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("any");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web App v1");
                c.RoutePrefix = string.Empty;
                    c.DefaultModelsExpandDepth(-1);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MyHUB>("/myhub");
                endpoints.MapControllers();

            });
        }
    }
}
