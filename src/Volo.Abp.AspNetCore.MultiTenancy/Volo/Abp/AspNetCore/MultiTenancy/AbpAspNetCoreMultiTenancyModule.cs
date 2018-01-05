﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.AspNetCore.MultiTenancy
{
    [DependsOn(typeof(AbpMultiTenancyAbstractionsModule), typeof(AbpAspNetCoreModule))]
    public class AbpAspNetCoreMultiTenancyModule : AbpModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TenantResolveOptions>(options =>
            {
                options.TenantResolvers.Insert(0, new QueryStringTenantResolver());
                options.TenantResolvers.Insert(1, new RouteTenantResolver());
                options.TenantResolvers.Insert(2, new HeaderTenantResolver());
                options.TenantResolvers.Insert(3, new CookieTenantResolver());
            });

            services.AddAssemblyOf<AbpAspNetCoreMultiTenancyModule>();
        }
    }
}
