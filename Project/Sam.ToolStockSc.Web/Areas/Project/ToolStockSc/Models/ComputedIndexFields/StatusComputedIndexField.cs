using Sitecore.Common;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Extensions;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ComputedIndexFields
{
    public class StatusComputedIndexField : IComputedIndexField
    {

        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            string result = null;
            var item = (Item)(indexable as SitecoreIndexableItem);

            if (item == null) return result;

            var statusId = item.Fields["Status"]?.GetValue(true);

            if (statusId == null) return result;

            var status = SitecoreConstants.MasterDatabase.Master.GetItem(statusId.ToGuid().ToID());

            return status.Fields["Name"]?.GetValue(true);
        }
    }
}