using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.Tool.Id)]
    public class ToolScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Name { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Manufacturer { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Droplink)]
        public virtual StatusScModel Status { get; set; }

        [SitecoreField(FieldId = Templates.Tool.Fields.ToolType)]
        public virtual ToolTypeScModel ToolType { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Droplink)]
        public virtual StockScModel Stock { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Droplink)]
        public virtual UserReferenceScModel User { get; set; }
    }
}