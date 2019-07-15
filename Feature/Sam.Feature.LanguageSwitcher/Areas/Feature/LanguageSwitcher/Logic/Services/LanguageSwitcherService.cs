using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Logic.Interfaces;
using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Models.ViewModels;
using Sam.Foundation.DependencyInjection;
using Sitecore.Data;
using Sitecore.Globalization;
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

            var languageViewModels = scLangs.Select(x => Create(x, currentUrl)).OrderBy(x => x.CountryName).ToList();

            return languageViewModels;
        }

        private LanguageLinkViewModel Create(Language language, string url)
        {
            var languageViewModel = new LanguageLinkViewModel
            {
                CountryName = language.CultureInfo.DisplayName,

            };

            var splitUrl = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (splitUrl.Count == 0 || splitUrl[0].Length != 2)
            {
                splitUrl.Insert(0, language.Name);
            }
            else
            {
                splitUrl[0] = language.Name;
            }

            languageViewModel.Link = "/" + String.Join("/", splitUrl);

            return languageViewModel;
        }
    }
}