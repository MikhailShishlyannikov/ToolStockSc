using System.Web.Mvc;

namespace Sam.Feature.Jumbotron.Areas.Jumbotron
{
    public class JumbotronAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Jumbotron";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Jumbotron_default",
                "Jumbotron/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}