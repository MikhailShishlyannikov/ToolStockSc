using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.ToolTypeCreating.Id)]
    public class ToolTypeCreatingScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Name { get; set; }
    }
}