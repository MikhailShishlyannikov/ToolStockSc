using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.NavLinkOption.Id, AutoMap = true)]
    public class NavLinkOptionScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string IconTag { get; set; }
    }
}