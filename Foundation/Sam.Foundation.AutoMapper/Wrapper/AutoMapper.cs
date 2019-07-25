using AutoMapper;
using Sam.Foundation.AutoMapper.Infrastructure;
using Sam.Foundation.DependencyInjection;

namespace Sam.Foundation.AutoMapper.Wrapper
{
    [Service(typeof(IMapper), Lifetime = Lifetime.Transient)]
    public class AutoMapper : Mapper
    {

        public AutoMapper() : base(new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(CustomAssemblyScaner.GetAssemblies());
        }))
        { }
    }
}