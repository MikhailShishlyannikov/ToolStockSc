using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.Feature.Card.Areas.Feature.Card.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.Card.Id, AutoMap = true)]
    public class CardScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Title { get; set; }
    }
}