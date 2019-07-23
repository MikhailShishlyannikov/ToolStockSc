using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using System.Collections.Generic;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.Rendering_Parameters
{
    [SitecoreType(TemplateId = Templates.MenuLinkRenderingParameter.Id, AutoMap = true)]
    public class MenuLinkRenderingParameter : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.Multilist)]
        public virtual IList<MenuLinkOptionScModel> Icons { get; set; }
    }
}