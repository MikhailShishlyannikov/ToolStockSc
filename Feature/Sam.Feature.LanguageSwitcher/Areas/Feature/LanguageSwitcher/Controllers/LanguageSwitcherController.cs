using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Logic.Interfaces;
using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Models.ViewModels;
using Sam.Foundation.GlassMapper.Controllers;
using System.Collections.Generic;
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
            return View("~/Areas/Feature/LanguageSwitcher/Views/LanguageSwitcher/LanguageSwitcher.cshtml", GetLinks());
        }

        public ActionResult LanguageSwitcherForSettingPage()
        {
            return View("~/Areas/Feature/LanguageSwitcher/Views/LanguageSwitcher/LanguageSwitcherForSettingPage.cshtml", GetLinks());
        }

        private IList<LanguageLinkViewModel> GetLinks()
        {
            var currentUrl = HttpContext.Request.Url.LocalPath;

            return _languageSwitcherService.GetLanguageLinks(currentUrl);
        }
    }
}