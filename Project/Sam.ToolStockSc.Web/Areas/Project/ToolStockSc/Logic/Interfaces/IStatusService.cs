using System.Collections.Generic;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<StatusScModel> GetAll();

        StatusScModel Get(string name);
    }
}
