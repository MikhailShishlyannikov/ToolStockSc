using System;
using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sitecore.SecurityModel;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(IUserReferenceService))]
    public class UserReferenceService : IUserReferenceService
    {
        private readonly SitecoreService _sitecoreService = new SitecoreService(SitecoreConstants.MasterDatabase.Master);

        public void Create(string userName)
        {
            using (new SecurityDisabler())
            {
                var referenceForNewUser = new UserReferenceScModel { Id = Guid.NewGuid(), UserName = userName };

                var itemName = userName.Split('\\')[1];
                itemName = itemName.Replace("@", "__");
                itemName = itemName.Replace('.', '_');
                
                // Add the item to the site tree
                var newItem =
                    SitecoreConstants.ParentItems.UserReferences.Add(itemName,
                        SitecoreConstants.TemplateItems.UserReference);

                // Set the new item in editing mode
                // Fields can only be updated when in editing mode
                // (It's like the begin tarnsaction on a database)
                newItem.Editing.BeginEdit();
                try
                {
                    // Assign values to the fields of the new item
                    newItem.Fields["User"].Value = referenceForNewUser.UserName;

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

        public IEnumerable<UserReferenceScModel> GetAll()
        {
            return SitecoreConstants.ParentItems.UserReferences.Children.Select(x =>
                _sitecoreService.GetItem<UserReferenceScModel>(x));
        }

        public UserReferenceScModel Get(string userName)
        {
            return GetAll().FirstOrDefault(x => x.UserName == userName);
        }
    }
}