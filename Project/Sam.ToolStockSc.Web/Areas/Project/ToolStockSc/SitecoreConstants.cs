using Sitecore.Data;
using Sitecore.Data.Items;

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

            public static Item Departments =
                MasterDatabase.Master.GetItem(ID.Parse("{2B4D6D09-5059-4082-85A0-DB6C09903B43}"));

            public static Item ToolTypes =
                MasterDatabase.Master.GetItem(ID.Parse("{7AB262D5-F93D-4E96-A7BB-ACDC79F9BB3D}"));

        }

        public struct TemplateItems
        {
            public static TemplateItem UserReference =
                MasterDatabase.Master.GetItem(ID.Parse(Templates.UserReference.Id));

            public static TemplateItem ToolType =
                MasterDatabase.Master.GetItem(ID.Parse(Templates.ToolType.Id));
        }

        public struct PageItems
        {
            public static Item ToolTypeRename =
                MasterDatabase.Master.GetItem(ID.Parse("{B9E0DB48-F58D-455B-A97C-4000DBAECAAB}"));
        }
    }
}