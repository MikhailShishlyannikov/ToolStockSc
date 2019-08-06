using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Glass.Mapper.Sc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sitecore.Common;
using Sitecore.Data.Fields;
using Sitecore.SecurityModel;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(IStockService))]
    public class StockService : IStockService
    {
        private readonly IMapper _mapper;
        private readonly SitecoreService _sitecoreService = new SitecoreService(SitecoreConstants.MasterDatabase.Master);

        public StockService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<StockScModel> GetAll()
        {
            return SitecoreConstants.ParentItems.Stocks.Children.Select(x =>
                _sitecoreService.GetItem<StockScModel>(x));
        }

        public StockScModel Get(Guid id)
        {
            return _sitecoreService.GetItem<StockScModel>(id);
        }

        public void Update(StockScModel scModel)
        {
            using (new SecurityDisabler())
            {
                // Get item
                var item = SitecoreConstants.MasterDatabase.Master.GetItem(scModel.Id.ToID());

                item.Editing.BeginEdit();
                try
                {
                    // Assign values to the fields of the new item
                    item.Fields["Name"].Value = scModel.Name;
                    item.Fields["Department"].Value = scModel.Department.Id.ToString("B").ToUpper();

                    MultilistField userMultiList = item.Fields["Users"];

                    //clear multilist
                    foreach (var multiListItem in userMultiList.List)
                    {
                        userMultiList.Remove(multiListItem);
                    }

                    foreach (var user in scModel.Users)
                    {
                        userMultiList.Add(user.Id.ToID().ToString());
                    }

                    MultilistField toolMultiList = item.Fields["Tools"];

                    //clear multilist
                    foreach (var multiListItem in toolMultiList.List)
                    {
                        toolMultiList.Remove(multiListItem);
                    }

                    foreach (var tool in scModel.Tools)
                    {
                        toolMultiList.Add(tool.Id.ToID().ToString());
                    }

                    // End editing will write the new values back to the Sitecore
                    // database (It's like commit transaction of a database)
                    item.Editing.EndEdit();
                    CommonLogic.PublishItem(item);
                }
                catch (Exception ex)
                {
                    // The update failed, write a message to the log
                    Sitecore.Diagnostics.Log.Error("Could not update item " + item.Paths.FullPath + ": " + ex.Message, this); //TODO $"" и вынести в константу

                    // Cancel the edit (not really needed, as Sitecore automatically aborts
                    // the transaction on exceptions, but it wont hurt your code)
                    item.Editing.CancelEdit();
                }
            }
        }
    }
}