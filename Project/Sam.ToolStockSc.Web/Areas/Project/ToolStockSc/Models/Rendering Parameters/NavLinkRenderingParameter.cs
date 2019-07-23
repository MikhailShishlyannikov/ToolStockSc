using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.Rendering_Parameters
{
    [SitecoreType(TemplateId = Templates.NavLinkRenderingParameter.Id, AutoMap = true)]
    public class NavLinkRenderingParameter : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual NavLinkOptionScModel Icon { get; set; }
    }
}