using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.Error.Id, AutoMap = true)]
    public class ErrorScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string StatusCode { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string Message { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string LinkText { get; set; }
    }
}