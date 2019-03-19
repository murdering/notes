using HealthChecks.UI.Client;
using HealthCheckSample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace HealthCheckSample.Extensions
{
    /// <summary>
    /// 健康检查扩展方法
    /// </summary>
    public static class HealthCheckExtension
    {
        public static void AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var healthCheckBuilder = services.AddHealthChecksUI().AddHealthChecks();

            var hcConfig = configuration.GetSection("HealthChecks-UI:HealthChecks").Get<List<HealthCheckSetting>>();

            foreach (var hcSetting in hcConfig)
            {
                healthCheckBuilder.AddUrlGroup(new Uri(hcSetting.AppHealthCheckUri), name: hcSetting.Name,
                    tags: new[] { hcSetting.Name });
            }
        }

        public static void UseHealthChecks(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");

            var hcConfig = configuration.GetSection("HealthChecks-UI:HealthChecks").Get<List<HealthCheckSetting>>();

            foreach (var hcSetting in hcConfig)
            {
                var uri = new Uri(hcSetting.Uri);

                app.UseHealthChecks(uri.AbsolutePath, new HealthCheckOptions()
                {
                    Predicate = (check) => check.Tags.Contains(hcSetting.Name),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            }
        }
    }
}
