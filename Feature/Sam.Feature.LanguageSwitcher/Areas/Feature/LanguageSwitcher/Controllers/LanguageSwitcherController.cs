using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Logic.Interfaces;
using Sam.Foundation.GlassMapper.Controllers;
using System.Web.Mvc;

namespace Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Controllers
{
    public class LanguageSwitcherController : BaseController
    {
        private readonly ILanguageSwitcherService _languageSwitcherService;
        public LanguageSwitcherController(IMvcContext mvcContext, ILanguageSwitcherService languageSwitcherService) : base(mvcContext)
        {
            _languageSwitcherService = languageSwitcherService;
        }

        // GET: Feature/LanguageSwitcher
        public ActionResult LanguageSwitcher()
        {
            var currentUrl = HttpContext.Request.Url.LocalPath;

            var links = _languageSwitcherService.GetLanguageLinks(currentUrl);

            return View("~/Areas/Feature/LanguageSwitcher/Views/LanguageSwitcher/LanguageSwitcher.cshtml", links);
        }
    }
}