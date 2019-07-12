using Microsoft.Extensions.DependencyInjection;
using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Controllers;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Configurations
{
    public class LanguageSwitcherDependencyConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<LanguageSwitcherController>();
        }
    }
}