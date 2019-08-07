using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Sam.Foundation.DependencyInjection.Infrastructure
{
    public class MvcControllerServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvcControllers("*.Feature.*");
            serviceCollection.AddClassesWithServiceAttribute("*.Feature.*");

            serviceCollection.AddMvcControllers("*.Foundation.*");
            serviceCollection.AddClassesWithServiceAttribute("*.Foundation.*");

            serviceCollection.AddMvcControllers("*.ToolStockSc.*");
            serviceCollection.AddClassesWithServiceAttribute("*.ToolStockSc.*");
        }
    }
}