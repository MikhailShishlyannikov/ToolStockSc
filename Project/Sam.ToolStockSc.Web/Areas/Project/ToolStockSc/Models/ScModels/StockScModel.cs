using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.Stock.Id)]
    public class StockScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Name { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Droplink)]
        public virtual DepartmentScModel Department { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Multilist)]
        public virtual IEnumerable<UserReferenceScModel> Users { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Multilist)]
        public virtual IEnumerable<ToolScModel> Tools { get; set; }
    }
}