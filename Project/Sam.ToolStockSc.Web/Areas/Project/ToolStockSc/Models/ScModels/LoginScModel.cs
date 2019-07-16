using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.LoginForm.Id, AutoMap = true)]
    public class LoginScModel : BaseScModel
    {
        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string EmailField { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string PasswordField { get; set; }
    }
}