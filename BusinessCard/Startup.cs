namespace BusinessCard
{
    using BusinessCard.Data;
    using BusinessCard.Data.Entities.Users;
    using BusinessCard.Insfrastructure.Data;
    using BusinessCard.Insfrastructure.Providers;
    using BusinessCard.Options;
    using BusinessCard.Providers;
    using BusinessCard.Services.Badges;
    using BusinessCard.Services.Badges.Repository;
    using BusinessCard.Services.Users;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.Configure<DbConnectionString>(this.Configuration.GetSection("DbConnectionString"));
            services.AddSingleton<IDbConnectionStringProvider, DbConnectionStringProvider>();

            var connectionString = this.Configuration.GetSection("DbConnectionString").Get<DbConnectionString>();


            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString.Database));

            services.AddScoped<IAppDbContext, ApplicationDbContext>();
            services.AddScoped<IBadgesRepository, BadgesRepository>();
            services.AddScoped<IBadgeService, BadgeService>();

            services.AddScoped<IUserService, UserService>();


            services.AddIdentity<UserEntity, RoleEntity>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddRoles<RoleEntity>();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

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
