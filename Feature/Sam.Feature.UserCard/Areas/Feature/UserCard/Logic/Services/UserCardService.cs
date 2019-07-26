using Sam.Feature.UserCard.Areas.Feature.UserCard.Logic.Interfaces;
using Sam.Feature.UserCard.Areas.Feature.UserCard.Models.ViewModels;
using Sam.Foundation.DependencyInjection;
using System.Linq;

namespace Sam.Feature.UserCard.Areas.Feature.UserCard.Logic.Services
{
    [Service(typeof(IUserCardService))]
    public class UserCardService : IUserCardService
    {
        public UserCardViewModel Get()
        {
            var vm = new UserCardViewModel();

            var user = Sitecore.Security.Accounts.User.Current;
            vm.Name = user.Profile["UserName"];
            vm.Patronymic = user.Profile["Patronymic"];
            vm.Surname = user.Profile["Surname"];
            vm.Role = user.Roles.FirstOrDefault()?.Name.Split('\\')[1];

            return vm;
        }
    }
}