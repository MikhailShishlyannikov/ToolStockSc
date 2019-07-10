using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.Feature.Button.Areas.Feature.Button.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.Option.Id, AutoMap = true)]
    public class Option : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Class { get; set; }
    }
}