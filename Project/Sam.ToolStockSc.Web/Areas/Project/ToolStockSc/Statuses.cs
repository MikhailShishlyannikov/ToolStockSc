using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc
{
    public class Statuses
    {
        public static Item InStock =
            SitecoreConstants.MasterDatabase.Master.GetItem(ID.Parse("{3540BC6C-05BB-40AD-BDCA-E327CCC9944D}"));

        public static Item IssuedToUser =
            SitecoreConstants.MasterDatabase.Master.GetItem(ID.Parse("{71157EB3-24FC-4E7F-B8D2-9DC416850393}"));
    }
}