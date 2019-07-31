using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.Department.Id, AutoMap = true)]
    public class DepartmentScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Name { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Multilist)]
        public virtual IList<UserReferenceScModel> Users { get; set; }
    }
}