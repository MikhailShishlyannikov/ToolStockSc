using Microsoft.Extensions.DependencyInjection;
using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Controllers;
using Sitecore.DependencyInjection;

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