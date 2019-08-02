using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.Feature.TableCard.Areas.Feature.TableCard.Models.ScModel
{
    [SitecoreType(TemplateId = Templates.TableCard.Id, AutoMap = true)]
    public class TableCardScModel : BaseScModel
    {
        public virtual string Title { get; set; }
    }
}