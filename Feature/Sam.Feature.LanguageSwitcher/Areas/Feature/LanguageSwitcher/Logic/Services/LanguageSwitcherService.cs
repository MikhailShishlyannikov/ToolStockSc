using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Logic.Interfaces;
using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Models.ViewModels;
using Sam.Foundation.DependencyInjection;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Logic.Services
{
    [Service(typeof(ILanguageSwitcherService))]
    public class LanguageSwitcherService : ILanguageSwitcherService
    {
        public IList<LanguageLinkViewModel> GetLanguageLinks(string currentUrl)
        {
            var master = Database.GetDatabase("master");

            var scLangs = master.GetLanguages();

            var langs = new List<LanguageLinkViewModel>();

            foreach (var scLang in scLangs)
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

            return langs;
        }
    }
}