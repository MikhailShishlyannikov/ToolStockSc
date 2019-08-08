using Sam.Foundation.GlassMapper.Models;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sam.Feature.ToolCard.Areas.Feature.ToolCard.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.ToolCard.Id, AutoMap = true)]
    public class ToolCardScModel : BaseScModel
    {
        public virtual string Title { get; set; }
    }
}