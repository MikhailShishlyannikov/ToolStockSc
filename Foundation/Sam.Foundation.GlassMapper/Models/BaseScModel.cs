using Glass.Mapper.Sc.Configuration.Attributes;
using System;

namespace Sam.Foundation.GlassMapper.Models
{
    public class BaseScModel
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }
    }
}