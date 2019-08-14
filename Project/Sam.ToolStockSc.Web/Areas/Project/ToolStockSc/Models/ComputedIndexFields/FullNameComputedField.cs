using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Extensions;
using Sitecore.Security.Accounts;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ComputedIndexFields
{
    public class FullNameComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }
        public object ComputeFieldValue(IIndexable indexable)
        {
            string result = null;
            var item = (Item)(indexable as SitecoreIndexableItem);

            if (item == null) return result;

            var userName = item.Fields["User"]?.GetValue(true);
            var user = User.FromName(userName, false);

            if (user.Name == @"extranet\Fake user") return $"Choose a user";

            if (!user.IsInRole(@"extranet\User") && !user.IsInRole(@"extranet\Keeper")) return result;

            var name = user.Profile.GetCustomProperty("UserName");
            var patronymic = user.Profile.GetCustomProperty("Patronymic");
            var surname = user.Profile.GetCustomProperty("Surname");

            return patronymic.IsEmptyOrNull() ? $"{name} {surname}" : $"{name} {patronymic} {surname}";
        }
    }
}