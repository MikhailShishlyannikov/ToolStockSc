using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.ChangePassword.Id, AutoMap = true)]
    public class ChangePasswordScModel : BaseScModel
    {
        [SitecoreField(FieldId = Templates.ChangePassword.Fields.OldPasswordFiled, FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string OldPasswordField { get; set; }

        [SitecoreField(FieldId = Templates.ChangePassword.Fields.OldPasswordHelpText, FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string OldPasswordHelpText { get; set; }

        [SitecoreField(FieldId = Templates.ChangePassword.Fields.NewPasswordFiled, FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string NewPasswordField { get; set; }

        [SitecoreField(FieldId = Templates.ChangePassword.Fields.NewPasswordHelpText, FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string NewPasswordHelpText { get; set; }

        [SitecoreField(FieldId = Templates.ChangePassword.Fields.ConfirmPasswordFiled, FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string ConfirmPasswordField { get; set; }

        [SitecoreField(FieldId = Templates.ChangePassword.Fields.ConfirmPasswordHelpText, FieldType = SitecoreFieldType.SingleLineText)]
        public virtual string ConfirmPasswordHelpText { get; set; }
    }
}