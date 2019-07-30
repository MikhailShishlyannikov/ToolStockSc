using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Syndication;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc
{
    public static class SitecoreConstants
    {
        public struct MasterDatabase
        {
            public static Database Master = Sitecore.Data.Database.GetDatabase("master");
        }

        public struct ParentItems
        {
            public static Item UserReferences =
                MasterDatabase.Master.GetItem(ID.Parse("{9018BED5-3A86-4267-8EC5-497049DE6191}"));

        }

        public struct TemplateItems
        {
            public static TemplateItem UserReference =
                MasterDatabase.Master.GetItem(ID.Parse(Templates.UserReference.Id));
        }
    }
}