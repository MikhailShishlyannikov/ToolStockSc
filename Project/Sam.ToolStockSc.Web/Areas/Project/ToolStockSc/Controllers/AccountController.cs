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
            if (Sitecore.Context.PageMode.IsExperienceEditor) return Login();

            if (!ModelState.IsValid) return Redirect($"{Sitecore.Context.Language.Name}/Log-In");

            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                var login = _accountService.Login(vm);

                if (!login) return Redirect($"/{Sitecore.Context.Language.Name}/Log-In");

                var user = Sitecore.Security.Accounts.User.FromName($"{vm.Email}", true);
                if (user.IsInRole(@"extranet\Keeper")) return Redirect($"/{Sitecore.Context.Language.Name}/keeper");
                if (user.IsInRole(@"extranet\User")) return Redirect($"/{Sitecore.Context.Language.Name}/user");
            }

            return Redirect($"/{Sitecore.Context.Language.Name}/Log-In");
        }

        public ActionResult Register()
        {
            var vm = _accountService.GetRegisterModel(_mvcContext);
            
            return View("~/Areas/Project/ToolStockSc/Views/Account/Register.cshtml", vm);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel vm)
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor)return Register();

            _accountService.AddUser(vm);

            return Redirect($"/{Sitecore.Context.Language.Name}/user");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Sitecore.Security.Authentication.AuthenticationManager.Logout();
            return Redirect($"/{Sitecore.Context.Language.Name}/Home");
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
            user?.ChangePassword(vm.OldPassword, vm.NewPassword);

            return Redirect(Sitecore.Security.Accounts.User.Current.IsInRole(@"extranet\Keeper")
                ? $"/{Sitecore.Context.Language.Name}/Keeper/Settings"
                : $"/{Sitecore.Context.Language.Name}/User/Settings");
        }

        public ActionResult ProfileEditing()
        {
            var vm = _accountService.GetProfileEditingModel(_mvcContext);

            return View("~/Areas/Project/ToolStockSc/Views/Account/ProfileEditing.cshtml", vm);
        }

        [HttpPost]
        public ActionResult ProfileEditing(ProfileEditingViewModel vm)
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor)return ProfileEditing();

            _accountService.UpdateProfile(vm);

            return Redirect(Sitecore.Security.Accounts.User.Current.IsInRole(@"extranet\Keeper")
                ? $"/{Sitecore.Context.Language.Name}/Keeper/Profile"
                : $"/{Sitecore.Context.Language.Name}/User/Profile");
        }
    }
}