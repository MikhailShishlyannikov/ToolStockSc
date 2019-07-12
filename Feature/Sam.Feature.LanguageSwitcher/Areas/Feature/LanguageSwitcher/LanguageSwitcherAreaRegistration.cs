using System.Web.Mvc;

namespace Sam.Feature.LanguageSwitcher.Areas.LanguageSwitcher
{
    public class LanguageSwitcherAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LanguageSwitcher";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LanguageSwitcher_default",
                "LanguageSwitcher/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}