﻿using Microsoft.AspNetCore.Authentication;

namespace Mango.Web.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "iodc";
            })
            .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = configuration["ServiceUrls:IdentityAPI"];
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClientId = "mango";
                options.ClientSecret = "secret";
                options.ResponseType = "code";
                //options.ClaimActions.MapJsonKey("role", "role", "role");
                //options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                options.TokenValidationParameters.NameClaimType = "name";
                options.TokenValidationParameters.RoleClaimType = "role";
                options.Scope.Add("mango");
                options.SaveTokens = true;

            });
        }
    }
}
