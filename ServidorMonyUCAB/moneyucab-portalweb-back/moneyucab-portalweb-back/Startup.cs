using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.Contextos;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.IdentityExtentions;
using moneyucab_portalweb_back.Migrations;
using moneyucab_portalweb_back.Models;
using System;
using System.Text;

namespace moneyucab_portalweb_back
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
            // Inject App Settings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            //RF12
            services.AddDbContext<DatosUsuarioDBContext> (options =>
                   options.UseNpgsql(Configuration.GetConnectionString("IdentityConnection")));

            services.AddTransient<EntityDatosUsuario, EntityDatosUsuario>();
            //
            services.AddControllers();

            // Servicio que realiza la enlace con la BD por medio de un string de conexión.
            services.AddDbContext<AuthenticationContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<AuthenticationContext>()
                .AddUserManager<ApplicationUserManager>() // Probar sin esto
                .AddDefaultTokenProviders();


            // SendGrid services
            services.AddSendGridEmailSender();

            // Servicio que configura las validaciones que deben cumplir las contraseñas de los usuarios
            services.Configure<IdentityOptions>(options =>
            {
                // Password options
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

                // Lockout options
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 3;

            }
            );

            services.AddCors();

            // JWT Authentication
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Permite el enlance entre requests del front al servidor
            app.UseCors(builder =>
                builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            );

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
