using Duende.IdentityServer.Services;
using Mango.Services.Identity.DbContexts;
using Mango.Services.Identity.Initializer;
using Mango.Services.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.Identity.Extension
{
    public static class ServicesExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static void ConfigureIdentity(this IServiceCollection services) =>
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders(); // Token providers are used when you forget your password

        //public static void ConfigureIdentityServer(this IServiceCollection services)
        //{
        //    var builder = services.AddIdentityServer(options =>
        //    {
        //        options.Events.RaiseErrorEvents = true;
        //        options.Events.RaiseInformationEvents = true;
        //        options.Events.RaiseFailureEvents = true;
        //        options.Events.RaiseSuccessEvents = true;
        //        options.EmitStaticAudienceClaim = true;
        //    }).AddInMemoryIdentityResources(SD.IdentityResources)
        //     .AddInMemoryApiScopes(SD.ApiScopes)
        //     .AddInMemoryClients(SD.Clients)
        //    .AddAspNetIdentity<ApplicationUser>();

        //    services.AddScoped<IDbInitializer, DbInitializer>();
        //    //services.AddScoped<IProfileService, ProfileService>();

        //    builder.AddDeveloperSigningCredential(); // Automatically generates a key and adds it only for development purposes


        //}

    }
}
