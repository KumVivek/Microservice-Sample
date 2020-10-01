using Math.Api.Base.Common;
using Math.Api.Base.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Math.Api.Base.Base
{
    public class BaseStartup
    {
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddCustomCors();
            services.AddSwaggerService();
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseCors(ApiBaseConstants.CORS_POLICY);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Assembly.GetEntryAssembly().GetName().Name);
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
