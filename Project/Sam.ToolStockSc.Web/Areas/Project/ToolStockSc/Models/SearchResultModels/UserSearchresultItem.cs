using System;
using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.SearchResultModels
{
    public class UserSearchResultItem : SearchResultItem
    {
        [IndexField("user_t")]
        public virtual string User { get; set; }

        [IndexField("tools_sm")]
        public virtual List<Guid> Tools { get; set; }

        [IndexField("stock_sm")]
        public virtual List<Guid> Stock { get; set; }

        [IndexField("fullname_s")]
        public virtual string FullName { get; set; }
    }
}