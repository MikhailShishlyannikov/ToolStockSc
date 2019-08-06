using System;
using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Buckets.Managers;
using Sitecore.SecurityModel;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(IToolService))]
    public class ToolService : IToolService
    {
        private readonly SitecoreService _sitecoreService = new SitecoreService(SitecoreConstants.MasterDatabase.Master);
        private readonly IToolTypeService _toolTypeService;
        private readonly IUserReferenceService _userReferenceService;
        private readonly IStockService _stockService;

        public ToolService(IToolTypeService toolTypeService, IUserReferenceService userReferenceService, IStockService stockService)
        {
            _toolTypeService = toolTypeService;
            _userReferenceService = userReferenceService;
            _stockService = stockService;
        }

        public IEnumerable<ToolScModel> GetAll()
        {
            return SitecoreConstants.ParentItems.Tools.Children.Select(x =>
                _sitecoreService.GetItem<ToolScModel>(x));
        }

        public IEnumerable<ToolScModel> Get(string name)
        {
            return GetAll().Where(x => x.Name == name);
        }

        public ToolScModel Get(Guid id)
        {
            return _sitecoreService.GetItem<ToolScModel>(id);
        }

        public void Create(ToolViewModel vm)
        {
            using (new SecurityDisabler())
            {
                for (var i = 0; i < vm.Amount; i++)
                {
                    var itemName = vm.Name.Replace('.', '_');
                    // Add the item to the site tree
                    var newItem =
                        SitecoreConstants.ParentItems.Tools.Add(itemName,
                            SitecoreConstants.TemplateItems.Tool);

                    // Set the new item in editing mode
                    // Fields can only be updated when in editing mode
                    // (It's like the begin tarnsaction on a database)
                    newItem.Editing.BeginEdit();
                    try
                    {
                        // Assign values to the fields of the new item
                        newItem.Fields["Name"].Value = vm.Name;
                        newItem.Fields["Manufacturer"].Value = vm.Manufacturer;
                        newItem.Fields["Status"].Value = vm.StatusId.ToString("B").ToUpper();
                        newItem.Fields["Tool Type"].Value = vm.ToolTypeId.ToString("B").ToUpper();
                        newItem.Fields["Stock"].Value = vm.StockId.ToString("B").ToUpper();
                        newItem.Fields["User"].Value = vm.UserName == SitecoreConstants.FakeUser.Fake.Fields["User"].Value
                            ? ""
                            : _userReferenceService.Get(vm.UserName).Id.ToString("B").ToUpper();

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

                    var newTool = Get(newItem.ID.ToGuid());

                    var toolType = _toolTypeService.Get(vm.ToolTypeId);
                    var tools = toolType.Tools.ToList();
                    tools.Add(newTool);
                    toolType.Tools = tools;
                    _toolTypeService.Update(toolType);

                    var stock = _stockService.Get(vm.StockId);
                    tools = stock.Tools.ToList();
                    tools.Add(newTool);
                    stock.Tools = tools;
                    _stockService.Update(stock);

                    if (vm.UserName == SitecoreConstants.FakeUser.Fake.Fields["User"].Value) continue;

                    var user = _userReferenceService.Get(vm.UserName);
                    tools = user.Tools.ToList();
                    tools.Add(newTool);
                    user.Tools = tools;
                    _userReferenceService.Update(user);
                }

                BucketManager.Sync(SitecoreConstants.ParentItems.Tools);
            }
        }
    }
}