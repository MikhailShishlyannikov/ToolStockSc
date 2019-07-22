using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Security.Accounts;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SitecoreService _sitecoreService = new SitecoreService(SitecoreConstants.MasterDatabase.Master);
        private readonly IAccountService _accountService;

        public AccountController(IMvcContext mvcContext, IAccountService accountService) : base(mvcContext)
        {
            _accountService = accountService;
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

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (new Sitecore.SecurityModel.SecurityDisabler())
                {
                    var login = _accountService.Login(model);

                    if (login)
                    {
                        var user = Sitecore.Security.Accounts.User.FromName($"{model.Email}", true);
                        if (user.IsInRole(@"extranet\Keeper")) return Redirect("/keeper");
                        if (user.IsInRole(@"extranet\User")) return Redirect("/user");
                    }
                }
            }
            return Redirect("/Log-In");
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

        [HttpPost]
        public ActionResult Register(RegisterViewModel vm)
        {
            _accountService.AddUser(vm);
            return Redirect("/user");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Sitecore.Security.Authentication.AuthenticationManager.Logout();
            return Redirect("/Home");
        }

        public ActionResult NavBar()
        {
            var user = Sitecore.Security.Accounts.User.Current;
            return View("~/Areas/Project/ToolStockSc/Views/Account/NavBar.cshtml", user);
        }
    }
}