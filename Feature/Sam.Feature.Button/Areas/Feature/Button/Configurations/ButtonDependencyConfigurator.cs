using Microsoft.Extensions.DependencyInjection;
using Sam.Feature.Button.Areas.Feature.Button.Controllers;
using Sitecore.DependencyInjection;

namespace Sam.Feature.Button.Areas.Feature.Button.Configurations
{
    public class ButtonDependencyConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ButtonController>();
        }
    }
}