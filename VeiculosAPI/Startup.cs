using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using VeiculosAPI.Repository;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService;
using VeiculosAPI.Services.BaseService.Interfaces;
using VeiculosAPI.Services.AuthService;
using VeiculosAPI.Services.MarcaService;
using VeiculosAPI.Services.MarcaService.Interfaces;
using VeiculosAPI.Services.ModeloService;
using VeiculosAPI.Services.ModeloService.Interfaces;
using VeiculosAPI.Repository.DTOs;
using AutoMapper;
using VeiculosAPI.Core;
using VeiculosAPI.Services.UsuarioService.Interfaces;
using VeiculosAPI.Services.UsuarioService;

namespace VeiculosAPI
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
            services.AddDbContext<VeiculosDb>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("MySqlConnectionString"),
                    MySqlServerVersion.LatestSupportedServerVersion,
                    options =>
                    {
                        options.MigrationsAssembly(typeof(VeiculosDb).Assembly.FullName);
                        options.EnableRetryOnFailure(12, TimeSpan.FromSeconds(5), null);
                    })
                );

            services.AddCors(options => options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin()));

            MapperConfiguration mappingConfig = new(mc => mc.AddProfile(new MappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var key = Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]);

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddApiVersioning();

            services.AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation(config => config.RegisterValidatorsFromAssembly(typeof(Modelo).Assembly));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "VeiculosAPI", Version = "v1" }));

            services.AddScoped<IBaseService<BaseModel, BaseCreateDTO, BaseEditDTO>, BaseService<BaseModel, BaseCreateDTO, BaseEditDTO>>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VeiculosAPI_v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
