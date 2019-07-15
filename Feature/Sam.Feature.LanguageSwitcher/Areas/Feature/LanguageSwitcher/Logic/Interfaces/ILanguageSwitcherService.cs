using Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Models.ViewModels;
using System.Collections.Generic;

namespace Sam.Feature.LanguageSwitcher.Areas.Feature.LanguageSwitcher.Logic.Interfaces
{
    public interface ILanguageSwitcherService
    {
        IList<LanguageLinkViewModel> GetLanguageLinks(string currentUrl);
    }
}
