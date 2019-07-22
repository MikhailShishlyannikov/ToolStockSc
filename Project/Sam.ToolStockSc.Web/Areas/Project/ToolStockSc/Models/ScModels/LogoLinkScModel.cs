using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sam.Foundation.GlassMapper.Models;
using Sitecore.Data.Items;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.LogoLink.Id, AutoMap = true)]
    public class LogoLinkScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.GeneralLink)]
        public virtual Link Link { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Image)]
        public virtual Image Logo { get; set; }
    }
}