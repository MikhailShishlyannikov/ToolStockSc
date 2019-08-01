using System;
using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sitecore.Common;
using Sitecore.Data.Fields;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(IDepartmentService))]
    public class DepartmentService : IDepartmentService
    {
        private readonly SitecoreService _sitecoreService = new SitecoreService(SitecoreConstants.MasterDatabase.Master);


        public IEnumerable<DepartmentScModel> GetAll()
        {
            return SitecoreConstants.ParentItems.Departments.Children.Select(x =>
                _sitecoreService.GetItem<DepartmentScModel>(x));
        }

        public DepartmentScModel Get(Guid id)
        {
            return _sitecoreService.GetItem<DepartmentScModel>(id);
        }

        public void Update(DepartmentScModel department)
        {
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                // Get item
                var item = SitecoreConstants.MasterDatabase.Master.GetItem(department.Id.ToID());

                // Set the new item in editing mode
                // Fields can only be updated when in editing mode
                // (It's like the begin tarnsaction on a database)
                item.Editing.BeginEdit();
                try
                {
                    item.Fields["Name"].Value = department.Name;

                    MultilistField userMultiList = item.Fields["Users"];

                    //clear multilist
                    foreach (var multiListItem in userMultiList.List)
                    {
                        userMultiList.Remove(multiListItem);
                    }

                    foreach (var user in department.Users)
                    {
                        userMultiList.Add(user.Id.ToID().ToString());
                    }

                    MultilistField stockMultiList = item.Fields["Stocks"];

                    //clear multilist
                    foreach (var multiListItem in stockMultiList.List)
                    {
                        stockMultiList.Remove(multiListItem);
                    }

                    foreach (var stock in department.Stocks)
                    {
                        stockMultiList.Add(stock.Id.ToID().ToString());
                    }

                    item.Editing.EndEdit();
                    CommonLogic.PublishItem(item);
                }
                catch (Exception ex)
                {
                    // The update failed, write a message to the log
                    Sitecore.Diagnostics.Log.Error("Could not update item " + item.Paths.FullPath + ": " + ex.Message, this);

                    // Cancel the edit (not really needed, as Sitecore automatically aborts
                    // the transaction on exceptions, but it wont hurt your code)
                    item.Editing.CancelEdit();
                }
            }
        }
    }
}