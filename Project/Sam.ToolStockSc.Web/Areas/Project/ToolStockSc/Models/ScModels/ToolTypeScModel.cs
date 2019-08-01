using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.ToolType.Id)]
    public class ToolTypeScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Name { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Multilist)]
        public virtual IEnumerable<ToolScModel> Tools { get; set; }
    }
}