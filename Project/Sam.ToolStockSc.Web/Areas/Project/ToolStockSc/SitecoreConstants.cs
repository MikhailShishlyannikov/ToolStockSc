using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc
{
    public static class SitecoreConstants
    {
        public struct MasterDatabase
        {
            public static Database Master = Sitecore.Data.Database.GetDatabase("master");
        }
    }
}