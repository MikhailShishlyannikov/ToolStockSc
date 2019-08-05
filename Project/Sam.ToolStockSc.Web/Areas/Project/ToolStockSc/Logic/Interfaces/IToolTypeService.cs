using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces
{
    public interface IToolTypeService
    {
        void Create(ToolTypeCreatingViewModel vm);

        IEnumerable<ToolTypeViewModel> GetAll();

        ToolTypeViewModel Get(Guid id);

        void Update(ToolTypeViewModel vm);
    }
}
