using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Data;
using System.Linq;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SitecoreService _sitecoreService = new SitecoreService(SitecoreConstants.MasterDatabase.Master);

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

        public ActionResult Register()
        {
            var vm = new RegisterViewModel();
            var scModel = _mvcContext.GetDataSourceItem<RegisterScModel>();
            var master = SitecoreConstants.MasterDatabase.Master;
            var departments = master.GetItem("/sitecore/content/Sam/ToolStockSc/Shared Site Content/Data/Departments")
                .Children.Select(x => _sitecoreService.GetItem<DepartmentScModel>(x)).OrderBy(x => x.Name).ToList();

            vm.Id = scModel.Id;
            vm.NameField = scModel.NameField;
            vm.PatronymicField = scModel.PatronymicField;
            vm.SurnameField = scModel.SurnameField;
            vm.PhoneField = scModel.PhoneField;
            vm.EmailField = scModel.EmailField;
            vm.PasswordField = scModel.PasswordField;
            vm.ConfirmPasswordField = scModel.ConfirmPasswordField;
            vm.DepartmentField = scModel.DepartmentField;
            vm.Departments = departments;

            return View("~/Areas/Project/ToolStockSc/Views/Account/Register.cshtml", vm);
        }
    }
}