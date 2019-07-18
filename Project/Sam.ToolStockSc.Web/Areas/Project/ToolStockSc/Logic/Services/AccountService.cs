using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Security.Accounts;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    /// <summary>
    /// This class will be responsible for:
    /// 1. Adding new users
    /// 2. Assigning roles
    /// 3. Login
    /// </summary>
    [Service(typeof(IAccountService))]
    public class AccountService : IAccountService
    {
        public bool Login(LoginViewModel vm)
        {
            vm.Email = string.Format(@"{0}\{1}", "extranet", vm.Email);
            try
            {
                if (Sitecore.Security.Authentication.AuthenticationManager.Login(vm.Email, vm.Password))
                {
                    return true;
                }
            }
            catch (System.Security.Authentication.AuthenticationException exception)
            {
                Sitecore.Diagnostics.Log.Error(exception.StackTrace + " login error", "");
            }

            return false;
        }

        public static User GetUser(string domainName, string userName, string password)
        {
            if (!System.Web.Security.Membership.ValidateUser(domainName + @"\" + userName, password))
                return null;
            if (User.Exists(domainName + @"\" + userName))
                return User.FromName(domainName + @"\" + userName, true);
            return null;
        }

        public void AddUser(RegisterViewModel vm)
        {
            throw new System.NotImplementedException();
        }

        public void AssignUserToRole(string domain, string firstName, string lastName, bool isSuperUser)
        {
            throw new System.NotImplementedException();
        }

        
    }
}