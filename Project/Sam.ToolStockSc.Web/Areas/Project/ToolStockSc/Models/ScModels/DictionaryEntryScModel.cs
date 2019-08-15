using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.DictinaryEntry.Id, AutoMap = true)]
    public class DictionaryEntryScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.MultiLineText)]
        public virtual string Key { get; set; }
    }
}