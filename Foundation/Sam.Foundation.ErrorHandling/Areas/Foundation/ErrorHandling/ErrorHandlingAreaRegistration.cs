using System.Web.Mvc;

namespace Sam.Foundation.ErrorHandling.Areas.ErrorHandling
{
    public class ErrorHandlingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ErrorHandling";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ErrorHandling_default",
                "ErrorHandling/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}