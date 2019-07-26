using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.UserCard.Areas.Feature.UserCard.Logic.Interfaces;
using Sam.Foundation.GlassMapper.Controllers;
using System.Web.Mvc;

namespace Sam.Feature.UserCard.Areas.Feature.UserCard.Controllers
{
    public class UserCardController : BaseController
    {
        private readonly IUserCardService _userCardService;

        public UserCardController(IMvcContext mvcContext, IUserCardService userCardService) : base(mvcContext)
        {
            _userCardService = userCardService;
        }

        public ActionResult UserCard()
        {
            var vm = _userCardService.Get();

            return View("~/Areas/Feature/UserCard/Views/UserCard/UserCard.cshtml", vm);
        }
    }
}