using System;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.SecurityModel;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(IToolTypeService))]
    public class ToolTypeService : IToolTypeService
    {
        public void Create(ToolTypeCreatingViewModel vm)
        {
            using (new SecurityDisabler())
            {
                // Add the item to the site tree
                var newItem =
                    SitecoreConstants.ParentItems.ToolTypes.Add(vm.Name,
                        SitecoreConstants.TemplateItems.ToolType);

                // Set the new item in editing mode
                // Fields can only be updated when in editing mode
                // (It's like the begin tarnsaction on a database)
                newItem.Editing.BeginEdit();

                try
                {
                    // Assign values to the fields of the new item
                    newItem.Fields["Name"].Value = vm.Name;

                    // End editing will write the new values back to the Sitecore
                    // database (It's like commit transaction of a database)
                    newItem.Editing.EndEdit();
                    CommonLogic.PublishItem(newItem);
                }
                catch (Exception ex)
                {
                    // The update failed, write a message to the log
                    Sitecore.Diagnostics.Log.Error("Could not update item " + newItem.Paths.FullPath + ": " + ex.Message, this); //TODO $"" и вынести в константу

                    // Cancel the edit (not really needed, as Sitecore automatically aborts
                    // the transaction on exceptions, but it wont hurt your code)
                    newItem.Editing.CancelEdit();
                }
            }
        }
    }
}