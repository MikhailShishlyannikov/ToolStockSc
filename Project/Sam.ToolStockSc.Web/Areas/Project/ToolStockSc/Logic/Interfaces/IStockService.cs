using System;
using System.Collections.Generic;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces
{
    public interface IStockService
    {
        IEnumerable<StockScModel> GetAll();

        StockScModel Get(Guid id);

        void Update(StockScModel scModel);
    }
}
