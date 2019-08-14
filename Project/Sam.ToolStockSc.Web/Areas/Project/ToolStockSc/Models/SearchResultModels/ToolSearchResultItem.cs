using System;
using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.SearchResultModels
{
    public class ToolSearchResultItem : SearchResultItem
    {
        [IndexField("name_t")]
        public virtual string ToolName { get; set; }

        [IndexField("manufacturer_t")]
        public virtual string Manufacturer { get; set; }

        [IndexField("tool_type_sm")]
        public virtual List<Guid> ToolType { get; set; }

        [IndexField("user_sm")]
        public virtual List<Guid> User { get; set; }

        [IndexField("stock_sm")]
        public virtual List<Guid> Stock { get; set; }

        [IndexField("status_sm")]
        public virtual List<Guid> Status { get; set; }
    }
}