using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Glass.Mapper;
using Glass.Mapper.Sc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Common;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.SecurityModel;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(IToolTypeService))]
    public class ToolTypeService : IToolTypeService
    {
        private readonly IMapper _mapper;
        private readonly SitecoreService _sitecoreService = new SitecoreService(SitecoreConstants.MasterDatabase.Master);

        public ToolTypeService(IMapper mapper)
        {
            _mapper = mapper;
        }

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

        public IEnumerable<ToolTypeViewModel> GetAllViewModels()
        {
            var urlToPage =
                LinkManager.GetItemUrl(_sitecoreService.GetItem<Item>(SitecoreConstants.PageItems.ToolTypeRename));

            var toolTypes =  _mapper.Map<IEnumerable<ToolTypeViewModel>>(
                SitecoreConstants.ParentItems.ToolTypes.Children.Select(x =>
                    _sitecoreService.GetItem<ToolTypeScModel>(x)));

            return toolTypes.ForEach(x => x.UrlForRename = $"{urlToPage}?id={x.Id}");
        }

        public IEnumerable<ToolTypeScModel> GetAll()
        {
            return SitecoreConstants.ParentItems.ToolTypes.Children.Select(x =>
                _sitecoreService.GetItem<ToolTypeScModel>(x));
        }

        public ToolTypeScModel Get(Guid id)
        {
            return _sitecoreService.GetItem<ToolTypeScModel>(id);
        }

        public ToolTypeViewModel GetViewModel(Guid id)
        {
            return _mapper.Map<ToolTypeViewModel>(_sitecoreService.GetItem<ToolTypeScModel>(id));
        }

        public void Update(ToolTypeViewModel vm)
        {
            using (new SecurityDisabler())
            {
                // Get item
                var item = SitecoreConstants.MasterDatabase.Master.GetItem(vm.Id.ToID());

                // Set the new item in editing mode
                // Fields can only be updated when in editing mode
                // (It's like the begin tarnsaction on a database)
                item.Editing.BeginEdit();

                try
                {
                    item.Fields["Name"].Value = vm.Name;

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

        public void Update(ToolTypeScModel scModel)
        {
            using (new SecurityDisabler())
            {
                // Get item
                var item = SitecoreConstants.MasterDatabase.Master.GetItem(scModel.Id.ToID());

                // Set the new item in editing mode
                // Fields can only be updated when in editing mode
                // (It's like the begin tarnsaction on a database)
                item.Editing.BeginEdit();
                try
                {
                    item.Fields["Name"].Value = scModel.Name;

                    MultilistField toolsMultiList = item.Fields["Tools"];

                    //clear multilist
                    foreach (var multiListItem in toolsMultiList.List)
                    {
                        toolsMultiList.Remove(multiListItem);
                    }

                    foreach (var tool in scModel.Tools)
                    {
                        toolsMultiList.Add(tool.Id.ToID().ToString());
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