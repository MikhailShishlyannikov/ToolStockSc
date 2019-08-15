using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.Actions.Id, AutoMap = true)]
    public class ActionsScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Amount { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Action { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Droplink)]
        public virtual DictionaryEntryScModel Button { get; set; }
    }
}