using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Sam.Foundation.LinkManager.Providers
{
    /// <summary>
    /// Sitecore Linkprovider for mixed configuration with multilanguage and not multilanguage websites. change the urloptions depends on the current website
    /// to use patch te web.config see the example in App_Config/Include/MirabeauLinkProvider.config
    /// </summary>
    public class ToolStockScLinkProvider : LinkProvider
    {
        private static HashSet<string> multiLanguageSites;
        public override void Initialize(string name, NameValueCollection config)
        {
            var sites = config.Get("multiLanguageSites");
            Log.Info("ToolStockSc linkprovider Initialize :" + sites, this.GetType());
            multiLanguageSites = new HashSet<string>();
            if (!string.IsNullOrWhiteSpace(sites))
            {
                foreach (var site in sites.Split(','))
                {
                    multiLanguageSites.Add(site.Trim().ToLower());
                }
            }
            base.Initialize(name, config);
        }

        public override string GetItemUrl(Item item, UrlOptions options)
        {
            var newOptions = options;
            newOptions.LanguageEmbedding = LanguageEmbedding.Always;
            newOptions.UseDisplayName = true; //this is also a option to set.

            //a new interpretation of the LanguageEmbedding.AsNeeded it depend on the site.
            //if (options.LanguageEmbedding == LanguageEmbedding.AsNeeded)
            //{
            //    if (multiLanguageSites.Contains(options.Site.Name.ToLower()))
            //    {
            //        newOptions.LanguageEmbedding = LanguageEmbedding.Always;
            //        newOptions.UseDisplayName = true; //this is also a option to set.
            //    }
            //    else
            //    {
            //        newOptions.LanguageEmbedding = LanguageEmbedding.Never;
            //    }
            //}
            return base.GetItemUrl(item, newOptions);
        }
    }
}