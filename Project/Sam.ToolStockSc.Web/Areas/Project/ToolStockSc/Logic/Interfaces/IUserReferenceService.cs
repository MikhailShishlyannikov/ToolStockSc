using System.Collections.Generic;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces
{
    public interface IUserReferenceService
    {
        void Create(string userName);

        IEnumerable<UserReferenceScModel> GetAll();

        IEnumerable<UserReferenceScModel> GetAllByIndex();

        UserReferenceScModel Get(string userName);

        void Update(UserReferenceScModel user);

        
    }
}