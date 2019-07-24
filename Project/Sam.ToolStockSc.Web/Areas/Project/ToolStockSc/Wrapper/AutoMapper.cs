using AutoMapper;
using Sam.Foundation.DependencyInjection;
using System.Reflection;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Wrapper
{
    [Service(typeof(IMapper), Lifetime = Lifetime.Transient)]
    public class AutoMapper : Mapper
    {
        public AutoMapper() : base(new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(Assembly.GetExecutingAssembly());
        }))
        { }
    }
}