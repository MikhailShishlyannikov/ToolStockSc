using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IMvcContext mvcContext) : base(mvcContext)
        {
        }

        // GET: Project/Account
        public ActionResult Login()
        {
            var vm = new LoginViewModel();
            var scModel = _mvcContext.GetDataSourceItem<LoginScModel>();

            vm.Id = scModel.Id;
            vm.EmailField = scModel.EmailField;
            vm.PasswordField = scModel.PasswordField;

            return View("~/Areas/Project/ToolStockSc/Views/Account/Login.cshtml", vm);
        }
    }
}