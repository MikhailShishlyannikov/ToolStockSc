using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IMvcContext mvcContext, IAccountService accountService) : base(mvcContext)
        {
            _accountService = accountService;
        }

        public ActionResult Login()
        {
            var vm = _accountService.GetLoginModel(_mvcContext);

            return View("~/Areas/Project/ToolStockSc/Views/Account/Login.cshtml", vm);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                using (new Sitecore.SecurityModel.SecurityDisabler())
                {
                    var login = _accountService.Login(vm);

                    if (login)
                    {
                        var user = Sitecore.Security.Accounts.User.FromName($"{vm.Email}", true);
                        if (user.IsInRole(@"extranet\Keeper")) return Redirect("/keeper");
                        if (user.IsInRole(@"extranet\User")) return Redirect("/user");
                    }
                }
            }
            return Redirect("/Log-In");
        }

        public ActionResult Register()
        {
            var vm = _accountService.GetRegisterModel(_mvcContext);
            
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

        public ActionResult ChangePassword()
        {
            var vm = _accountService.GetChangePasswordModel(_mvcContext);

            return View("~/Areas/Project/ToolStockSc/Views/Account/ChangePassword.cshtml", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel vm)
        {
            var user = System.Web.Security.Membership.GetUser();
            user.ChangePassword(vm.OldPassword, vm.NewPassword);

            if (Sitecore.Security.Accounts.User.Current.IsInRole(@"extranet\Keeper")) return Redirect("/Keeper/Settings");

            return Redirect("/User/Settings");
        }
    }
}