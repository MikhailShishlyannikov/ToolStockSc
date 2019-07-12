using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Models.ViewModels;
using Sam.Foundation.GlassMapper.Controllers;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Controllers
{
    public class LanguageSwitcherController : BaseController
    {
        public LanguageSwitcherController(IMvcContext mvcContext) : base(mvcContext)
        {
        }

        // GET: Feature/LanguageSwitcher
        public ActionResult LanguageSwitcher()
        {
            var currentUrl = HttpContext.Request.Url.LocalPath;
            var master = Database.GetDatabase("master");

            var scLangs = master.GetLanguages();

            var langs = new List<LanguageLinkViewModel>();

            foreach(var scLang in scLangs)
            {
                var lang = new LanguageLinkViewModel
                {
                    CountryName = scLang.CultureInfo.DisplayName
                };

                var a = currentUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (a.Count == 0 || a[0].Length != 2)
                {
                    a.Insert(0, scLang.Name);
                }
                else
                {
                    a[0] = scLang.Name;
                }

                lang.Link = "/" + String.Join("/", a);

                langs.Add(lang);
            }

            return View("~/Areas/Feature/LanguageSwitcher/Views/LanguageSwitcher/LanguageSwitcher.cshtml", langs);
        }
    }
}