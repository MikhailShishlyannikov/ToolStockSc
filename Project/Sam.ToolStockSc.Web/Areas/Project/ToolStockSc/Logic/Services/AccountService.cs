using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Security.Accounts;
using Sitecore.SecurityModel;
using System;
using System.Web.Security;

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
                if (Sitecore.Security.Authentication.AuthenticationManager.Login(vm.Email, vm.Password, true))
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

        /// <summary>
        ///  Creates a new user and edits the profile custom fields
        ///  </summary>
        public void AddUser(RegisterViewModel vm)
        {
            string userName = vm.Email;
            userName = string.Format(@"{0}\{1}", "extranet", userName);
            string newPassword = vm.Password;
            try
            {
                if (!User.Exists(userName))
                {
                    Membership.CreateUser(userName, newPassword, vm.Email);

                    // Edit the profile information
                    User user = User.FromName(userName, true);

                    user.Roles.Add(Role.FromName(@"extranet\User"));

                    user.Profile.FullName = string.Format("{0} {1}", vm.Name, vm.Surname);

                    
                    using(new SecurityDisabler())
                    {
                        // Assigning the user profile template
                        user.Profile.ProfileItemId = "{2E513D92-2DD0-4E63-9B58-7E7B5CCC4E6D}";
                        user.Profile.Save();

                        // Have modified the user template to also contain telephone number and patronomyc.
                        user.Profile.SetCustomProperty("Patronymic", vm.Patronymic);
                        user.Profile.SetCustomProperty("Surname", vm.Surname);
                        user.Profile.SetCustomProperty("Phone", vm.Phone);
                        user.Profile.SetCustomProperty("UserName", vm.Name);
                        user.Profile.SetCustomProperty("Department", vm.DepartmentId.ToString());

                    }

                    user.Profile.Save();

                    Login(new LoginViewModel { Email = vm.Email, Password = vm.Password });
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(string.Format("Error in Sam.MySite.Logic.AccountService (AddUser): Message: {0}; Source:{1}", ex.Message, ex.Source), this);
            }
        }

        public void AssignUserToRole(string domain, string firstName, string lastName, bool isSuperUser)
        {
            throw new System.NotImplementedException();
        }

        
    }
}