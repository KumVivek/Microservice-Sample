using Math.Api.Base.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Math.Api.Base.Common
{
    internal static class BaseExtension
    {
        /// <summary>
        /// This method will configure the cors.
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(
                 options => options.AddPolicy(ApiBaseConstants.CORS_POLICY,
                     builder =>
                     {
                         builder
                             .AllowAnyOrigin()
                             .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
                             .AllowAnyHeader();
                     })
             );

        }

        /// <summary>
        /// This method will add the swagger service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetEntryAssembly().GetName().Name, Version = "v1" });                
            });
        }


    }
}
