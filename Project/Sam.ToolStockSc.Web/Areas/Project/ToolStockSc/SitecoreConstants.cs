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

            public static Item Stocks =
                MasterDatabase.Master.GetItem(ID.Parse("{4898302C-E4CC-4655-8FE7-CBE3B778CD0F}"));

            public static Item Statuses =
                MasterDatabase.Master.GetItem(ID.Parse("{B2265AE9-A406-4724-9D3C-8ABD5EEA811E}"));

            public static Item Tools =
                MasterDatabase.Master.GetItem(ID.Parse("{2FF7C929-4BCC-4CB3-80C3-0A3040CAA319}"));
        }

        public struct TemplateItems
        {
            public static TemplateItem UserReference =
                MasterDatabase.Master.GetItem(ID.Parse(Templates.UserReference.Id));

            public static TemplateItem ToolType =
                MasterDatabase.Master.GetItem(ID.Parse(Templates.ToolType.Id));

            public static TemplateItem Tool =
                MasterDatabase.Master.GetItem(ID.Parse(Templates.Tool.Id));

            public static TemplateItem Stock =
                MasterDatabase.Master.GetItem(ID.Parse(Templates.Stock.Id));
        }

        public struct PageItems
        {
            public static Item ToolTypeRename =
                MasterDatabase.Master.GetItem(ID.Parse("{B9E0DB48-F58D-455B-A97C-4000DBAECAAB}"));

            public static Item Issue =
                MasterDatabase.Master.GetItem(ID.Parse("{CCAFD326-4EDE-4D57-850B-FFB558FC8577}"));

            public static Item Keeper =
                MasterDatabase.Master.GetItem(ID.Parse("{BF6EA320-B7AE-4D6C-A586-62C78C5C5844}"));
        }

        public struct FakeUser
        {
            public static Item Fake =
                MasterDatabase.Master.GetItem(ID.Parse("{F3786F6C-7D71-4012-BAC0-80306B7A6B7D}"));
        }

        public struct Indexes
        {
            public struct Tool
            {
                public const string Tools = "sc910_web_tools_index";
            }

            public struct User
            {
                public const string Users = "sc910_web_users_index";
            }
        }
    }
}