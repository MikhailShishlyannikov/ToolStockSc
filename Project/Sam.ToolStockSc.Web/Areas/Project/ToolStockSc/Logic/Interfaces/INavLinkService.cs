using Glass.Mapper.Sc.Web.Mvc;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces
{
    public interface INavLinkService
    {
        NavLinkViewModel Get(IMvcContext mvcContext);
    }
}
