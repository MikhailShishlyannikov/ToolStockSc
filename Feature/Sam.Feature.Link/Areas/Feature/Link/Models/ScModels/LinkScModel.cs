using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;
using LinkSc = Glass.Mapper.Sc.Fields.Link;

namespace Sam.Feature.Link.Areas.Feature.Link.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.Link.Id, AutoMap = true)]
    public class LinkScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.GeneralLink)]
        public virtual LinkSc Link { get; set; }
    }
}