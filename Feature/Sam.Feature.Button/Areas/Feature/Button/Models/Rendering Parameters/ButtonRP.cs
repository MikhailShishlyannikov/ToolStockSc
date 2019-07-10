using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Feature.Button.Areas.Feature.Button.Models.ScModels;

namespace Sam.Feature.Button.Areas.Feature.Button.Models.Rendering_Parameters
{
    [SitecoreType(TemplateId = Templates.ButtonRP.Id, AutoMap = true)]
    public class ButtonRP
    {
        [SitecoreField(FieldType = SitecoreFieldType.Droplink)]
        public virtual Option Style { get; set; }
    }
}