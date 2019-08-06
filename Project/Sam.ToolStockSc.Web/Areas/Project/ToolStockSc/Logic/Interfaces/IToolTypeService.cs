using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces
{
    public interface IToolTypeService
    {
        void Create(ToolTypeCreatingViewModel vm);

        IEnumerable<ToolTypeViewModel> GetAllViewModels();

        IEnumerable<ToolTypeScModel> GetAll();

        ToolTypeScModel Get(Guid id);

        ToolTypeViewModel GetViewModel(Guid id);

        void Update(ToolTypeViewModel vm);

        void Update(ToolTypeScModel scModel);

    }
}
