using System;
using System.Collections.Generic;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentScModel> GetAll();

        DepartmentScModel Get(Guid id);

        void Update(DepartmentScModel department);
    }   
}
