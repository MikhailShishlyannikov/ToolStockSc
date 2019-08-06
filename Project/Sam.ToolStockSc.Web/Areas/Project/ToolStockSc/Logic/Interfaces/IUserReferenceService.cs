using System.Collections.Generic;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces
{
    public interface IUserReferenceService
    {
        void Create(string userName);

        IEnumerable<UserReferenceScModel> GetAll();

        UserReferenceScModel Get(string userName);

        void Update(UserReferenceScModel user);
    }
}