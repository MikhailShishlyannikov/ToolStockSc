using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.NavLinkDataSource.Id, AutoMap = true)]
    public class NavLinkScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.GeneralLink)]
        public virtual Link Link { get; set; }
    }
}