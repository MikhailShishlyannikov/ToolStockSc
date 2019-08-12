using System;
using System.Collections.Generic;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces
{
    public interface IToolService
    {
        IEnumerable<ToolScModel> GetAll();

        IEnumerable<ToolScModel> Get(string name);

        IEnumerable<ToolScModel> Get(string name, string manufacturer);

        ToolScModel Get(Guid Id);

        void Create(ToolViewModel vm);

        IEnumerable<ToolCountViewModel> GetAllToolCounts(bool showDeleted, Guid stockId, string name, string manufacturer);
    }
}
