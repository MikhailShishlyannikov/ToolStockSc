using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sam.Foundation.GlassMapper.Models;
using Sitecore.Security.Accounts;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels
{
    [SitecoreType(TemplateId = Templates.UserReference.Id, AutoMap = true)]
    public class UserReferenceScModel : BaseScModel
    {
        [SitecoreField(FieldId = Templates.UserReference.Fields.User)]
        public virtual string UserName { get; set; }

        [SitecoreField(FieldType = SitecoreFieldType.Multilist)]
        public virtual IEnumerable<ToolScModel> Tools { get; set; }

        public User User => User.FromName(UserName, true);
    }
}