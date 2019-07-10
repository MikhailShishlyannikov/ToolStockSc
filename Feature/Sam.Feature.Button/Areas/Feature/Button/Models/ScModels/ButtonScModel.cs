using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.Feature.Button.Areas.Feature.Button.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.Button.Id, AutoMap = true)]
    public class ButtonScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.GeneralLink)]
        public virtual Link Link { get; set; }
    }
}