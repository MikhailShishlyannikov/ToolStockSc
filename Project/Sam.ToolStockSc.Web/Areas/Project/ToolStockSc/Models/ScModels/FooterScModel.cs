using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.Footer.Id, AutoMap = true)]
    public class FooterScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Copyright { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Design { get; set; }
    }
}