using AutoMapper;
using System.Text;
using Marathon.Persistence;
using Marathon.API.Settings;
using Marathon.API.Services;
using Microsoft.AspNetCore.Http;
using Marathon.API.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marathon.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MarathonDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            BindCommonServices(services);

            // Add proper cookie request to follow GDPR 
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for 
                // non-essential cookies is needed for a given request
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add JWT Authentication for Api clients
            services.AddAuthentication().
                AddJwtBearer(options =>
                {
                    // Set validation parameters
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Validate issuer
                        ValidateIssuer = true,
                        // Validate audience
                        ValidateAudience = true,
                        // Validate expiration
                        ValidateLifetime = true,
                        // Validate signature
                        ValidateIssuerSigningKey = true,

                        // Set issuer
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        // Set audience
                        ValidAudience = Configuration["Jwt:Audience"],

                        // Set signing key
                        IssuerSigningKey = new SymmetricSecurityKey(
                            // Get our secret key from configuration
                            Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                    };
                });

            services.AddMvc();

            // Register the Swagger services
            services.AddSwaggerDocument();

            // Configure automapper
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new DefaultAutomapperProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            BuildAppSettingsProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Setup Identity
            app.UseAuthentication();

            // If in development...
            if (env.IsDevelopment())
            {
                // Show any exceptions in browser when they crash
                app.UseDeveloperExceptionPage();
            }
            // Otherwise...
            else
            {
                // Just show generic error page
                app.UseExceptionHandler("/Home/Error");

                // In production, tell the browsers (via the HSTS header)
                // to only try and access our site via HTTPS, not HTTP
                app.UseHsts();
            }

            // Serve static files
            app.UseStaticFiles();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwagger();
            app.UseSwaggerUi3();

            // Setup MVC routes
            app.UseMvcWithDefaultRoute();

        }

        /// <summary>
        /// Pass configuration parameters to <see cref="AppSettingsProvider"/>
        /// </summary>
        private void BuildAppSettingsProvider()
        {
            AppSettingsProvider.Jwt.SecretKey = Configuration["Jwt:SecretKey"];
            AppSettingsProvider.Jwt.Issuer = Configuration["Jwt:Issuer"];
            AppSettingsProvider.Jwt.Audience = Configuration["Jwt:Audience"];
        }

        /// <summary>
        /// Configures repository services for data access
        /// </summary>
        /// <remarks>
        /// Services that consume EF Core objects (DbContext) should be registered as Scoped
        /// (see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection#registering-your-own-services)
        /// </remarks>
        private void BindCommonServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRunnerService, RunnerService>();

            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IGenderService, GenderService>();

            services.AddScoped<IMarathonService, MarathonService>();

            services.AddScoped<IRaceKitService, RaceKitService>();
            services.AddScoped<ICharityService, CharityService>();
        }
    }
}