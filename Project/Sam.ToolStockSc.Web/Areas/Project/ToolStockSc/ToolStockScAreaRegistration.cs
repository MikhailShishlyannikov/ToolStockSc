using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.ToolStockSc
{
    public class ToolStockScAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ToolStockSc";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ToolStockSc_default",
                "ToolStockSc/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}