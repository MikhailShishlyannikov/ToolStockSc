using System;
using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.SearchResultModels;
using Sitecore.Common;
using Sitecore.ContentSearch;
using Sitecore.Data.Fields;
using Sitecore.Globalization;
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
                using (new LanguageSwitcher("en"))
                {
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
                        newItem.Fields["User"].Value = userName;

                        // End editing will write the new values back to the Sitecore
                        // database (It's like commit transaction of a database)
                        newItem.Editing.EndEdit();
                        CommonLogic.PublishItem(newItem);
                    }
                    catch (Exception ex)
                    {
                        // The update failed, write a message to the log
                        Sitecore.Diagnostics.Log.Error(
                            "Could not update item " + newItem.Paths.FullPath + ": " + ex.Message,
                            this); //TODO $"" и вынести в константу

                        // Cancel the edit (not really needed, as Sitecore automatically aborts
                        // the transaction on exceptions, but it wont hurt your code)
                        newItem.Editing.CancelEdit();
                    }
                }
            }
        }

        public IEnumerable<UserReferenceScModel> GetAll()
        {
            return SitecoreConstants.ParentItems.UserReferences.Children.Select(x =>
                _sitecoreService.GetItem<UserReferenceScModel>(x));
        }

        public IEnumerable<UserReferenceScModel> GetAllByIndex()
        {
            var items = Enumerable.Empty<UserReferenceScModel>();

            var index = ContentSearchManager.GetIndex(SitecoreConstants.Indexes.User.Users);

            using (var context = index.CreateSearchContext())
            {
                items = context.GetQueryable<UserSearchResultItem>()
                    .Select(x => new UserReferenceScModel
                    {
                        Id = x.ItemId.ToGuid(),
                        UserName = x.User,
                        Tools = _sitecoreService.GetItems<ToolScModel>(db => x.Tools.Select(t => db.GetItem(t.ToID()))),
                        FullName = x.FullName
                    }).ToList();
            }

            return items;
        }

        public UserReferenceScModel Get(string userName)
        {
            return GetAll().FirstOrDefault(x => x.UserName == userName);
        }

        public void Update(UserReferenceScModel user)
        {
            using (new SecurityDisabler())
            {
                using (new LanguageSwitcher("en"))
                {
                    // Add the item to the site tree
                    var item = SitecoreConstants.MasterDatabase.Master.GetItem(user.Id.ToID());

                    // Set the new item in editing mode
                    // Fields can only be updated when in editing mode
                    // (It's like the begin tarnsaction on a database)
                    item.Editing.BeginEdit();
                    try
                    {
                        item.Fields["User"].Value = user.UserName;

                        MultilistField toolsMultiList = item.Fields["Tools"];

                        //clear multilist
                        foreach (var multiListItem in toolsMultiList.List)
                        {
                            toolsMultiList.Remove(multiListItem);
                        }

                        foreach (var tool in user.Tools)
                        {
                            toolsMultiList.Add(tool.Id.ToID().ToString());
                        }

                        item.Editing.EndEdit();
                        CommonLogic.PublishItem(item);
                    }
                    catch (Exception ex)
                    {
                        // The update failed, write a message to the log
                        Sitecore.Diagnostics.Log.Error(
                            "Could not update item " + item.Paths.FullPath + ": " + ex.Message, this);

                        // Cancel the edit (not really needed, as Sitecore automatically aborts
                        // the transaction on exceptions, but it wont hurt your code)
                        item.Editing.CancelEdit();
                    }
                }
            }
        }
    }
}