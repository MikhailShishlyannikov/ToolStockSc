using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Glass.Mapper.Sc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.SearchResultModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Buckets.Managers;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.Globalization;
using Sitecore.Mvc.Extensions;
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
        private readonly IMapper _mapper;

        public ToolService(IToolTypeService toolTypeService, IUserReferenceService userReferenceService, IStockService stockService, IMapper mapper)
        {
            _toolTypeService = toolTypeService;
            _userReferenceService = userReferenceService;
            _stockService = stockService;
            _mapper = mapper;
        }

        public IEnumerable<ToolScModel> GetAll()
        {
            var items = Enumerable.Empty<ToolScModel>();

            var index = ContentSearchManager.GetIndex(SitecoreConstants.Indexes.Tool.Tools);
            using (var context = index.CreateSearchContext())
            {
                items = context.GetQueryable<ToolSearchResultItem>()
                    .Select(x => new ToolScModel
                    {
                        Id = x.ItemId.ToGuid(),
                        Name = x.ToolName,
                        Manufacturer = x.Manufacturer,
                        ToolType = _sitecoreService.GetItem<ToolTypeScModel>(x.ToolType.FirstOrDefault()),
                        User = _sitecoreService.GetItem<UserReferenceScModel>(x.User.FirstOrDefault()),
                        Status = _sitecoreService.GetItem<StatusScModel>(x.Status.FirstOrDefault()),
                        Stock = _sitecoreService.GetItem<StockScModel>(x.Stock.FirstOrDefault())
                    }).ToList();
            }
            return items;
        }

        public IEnumerable<ToolScModel> Get(string name)
        {
            var items = Enumerable.Empty<ToolScModel>();

            var index = ContentSearchManager.GetIndex(SitecoreConstants.Indexes.Tool.Tools);
            using (var context = index.CreateSearchContext())
            {
                var predicate = PredicateBuilder.True<ToolSearchResultItem>();
                predicate = predicate.And(x => x.Name == name);

                items = context.GetQueryable<ToolSearchResultItem>().Where(predicate)
                    .Select(x => new ToolScModel
                    {
                        Id = x.ItemId.ToGuid(),
                        Name = x.ToolName,
                        Manufacturer = x.Manufacturer,
                        ToolType = _sitecoreService.GetItem<ToolTypeScModel>(x.ToolType.FirstOrDefault()),
                        User = _sitecoreService.GetItem<UserReferenceScModel>(x.User.FirstOrDefault()),
                        Status = _sitecoreService.GetItem<StatusScModel>(x.Status.FirstOrDefault()),
                        Stock = _sitecoreService.GetItem<StockScModel>(x.Stock.FirstOrDefault())
                    }).ToList();
            }
            return items;
        }

        public IEnumerable<ToolScModel> Get(string name, string manufacturer)
        {
            var items = Enumerable.Empty<ToolScModel>();

            var index = ContentSearchManager.GetIndex(SitecoreConstants.Indexes.Tool.Tools);
            using (var context = index.CreateSearchContext())
            {
                var predicate = PredicateBuilder.True<ToolSearchResultItem>();
                if(!name.IsEmptyOrNull() && (!manufacturer.IsEmptyOrNull() && manufacturer != Translate.Text("Searching.ChooseManufacturer")))
                {
                    predicate = predicate.And(x => x.Name.Contains(name) && x.Manufacturer == manufacturer);
                }
                if (name.IsEmptyOrNull() && (!manufacturer.IsEmptyOrNull() && manufacturer != Translate.Text("Searching.ChooseManufacturer")))
                {
                    predicate = predicate.And(x => x.Manufacturer == manufacturer);
                }
                if (!name.IsEmptyOrNull() && (manufacturer.IsEmptyOrNull() || manufacturer == Translate.Text("Searching.ChooseManufacturer")))
                {
                    predicate = predicate.And(x => x.Name.Contains(name));
                }

                items = context.GetQueryable<ToolSearchResultItem>().Where(predicate)
                    .Select(x => new ToolScModel
                    {
                        Id = x.ItemId.ToGuid(),
                        Name = x.ToolName,
                        Manufacturer = x.Manufacturer,
                        ToolType = _sitecoreService.GetItem<ToolTypeScModel>(x.ToolType.FirstOrDefault()),
                        User = _sitecoreService.GetItem<UserReferenceScModel>(x.User.FirstOrDefault()),
                        Status = _sitecoreService.GetItem<StatusScModel>(x.Status.FirstOrDefault()),
                        Stock = _sitecoreService.GetItem<StockScModel>(x.Stock.FirstOrDefault())
                    }).ToList();
            }
            return items;
        }

        public ToolScModel Get(Guid id)
        {
            return _sitecoreService.GetItem<ToolScModel>(id);
        }

        public void Create(ToolViewModel vm)
        {
            using (new SecurityDisabler())
            {
                using (new LanguageSwitcher("en"))
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
                            newItem.Fields["User"].Value =
                                vm.UserName == SitecoreConstants.FakeUser.Fake.Fields["User"].Value
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
                            Sitecore.Diagnostics.Log.Error(
                                "Could not update item " + newItem.Paths.FullPath + ": " + ex.Message,
                                this); //TODO $"" и вынести в константу

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

        public IEnumerable<ToolCountViewModel> GetAllToolCounts(bool showDeleted, Guid stockId, string name, string manufacturer)
        {
            IEnumerable<ToolScModel> toolModels;

            if (stockId == new Guid())
            {
                toolModels = showDeleted
                    ? Get(name, manufacturer)
                    : Get(name, manufacturer).Where(t => t.Status.Name != "Written Off");
            }
            else
            {
                toolModels = showDeleted
                    ? Get(name, manufacturer).Where(t => t.Stock.Id == stockId)
                    : Get(name, manufacturer).Where(t => t.Status.Name != "Written Off" && t.Stock.Id == stockId);
            }

            var toolCounts = toolModels.GroupBy(t => t.Name)
                .Select(tc => new ToolCountViewModel
                {
                    Count = tc.Count(),
                    Name = tc.Key,
                    Manufacturer = tc.First().Manufacturer,
                    ToolTypeName = tc.FirstOrDefault()?.ToolType.Name,
                    StockCountViewModels = tc.Where(t => t.Name == tc.Key)
                        .GroupBy(t => t.Stock.Id)
                        .Select(x => new StockCountViewModel
                        {
                            StockId = x.FirstOrDefault()?.Stock.Id,
                            Name = x.FirstOrDefault()?.Stock.Name,
                            ToolAmount = x.Count(),
                            InStockToolAmount = x.Count(t => t.Status.Id == "{3540BC6C-05BB-40AD-BDCA-E327CCC9944D}".ToGuid()),
                            UnderRepairToolAmount = x.Count(t => t.Status.Id == "{D2F3433B-7A5C-4853-9053-4A31794515B5}".ToGuid()),
                            IssuedToUserToolAmount = x.Count(t => t.Status.Id == "{71157EB3-24FC-4E7F-B8D2-9DC416850393}".ToGuid()),
                            WrittenOffToolAmount = x.Count(t => t.Status.Id == "{0E255E65-8CE0-43AF-BC6B-EB0BCA9DF956}".ToGuid()),
                            UserCountViewModels = x.Where(t => t.Status.Id == "{71157EB3-24FC-4E7F-B8D2-9DC416850393}".ToGuid())
                                .Select(t => t.User)
                                .GroupBy(y => y.User.Profile.GetCustomProperty("UserName") + " " + y.User.Profile.GetCustomProperty("Patronymic") + " " + y.User.Profile.GetCustomProperty("Surname")) //TODO здесь можно сделать computed field
                                .Select(z => new UserCountViewModel
                                {
                                    UserId = z.FirstOrDefault()?.Id,
                                    FullName = z.FirstOrDefault()?.User.Profile.GetCustomProperty("UserName") + " " + z.FirstOrDefault()?.User.Profile.GetCustomProperty("Patronymic") + " " + z.FirstOrDefault()?.User.Profile.GetCustomProperty("Surname"),
                                    ToolAmount = z.Count()
                                }).ToList()
                        }).ToList()
                });

            return toolCounts;
        }
    }
}