using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Card.Areas.Feature.Card.Logic.Interfaces;
using Sam.Foundation.GlassMapper.Controllers;
using System.Web.Mvc;

namespace Sam.Feature.Card.Areas.Feature.Card.Controllers
{
    public class CardController : BaseController
    {
        private readonly ICardService _cardService;

        public CardController(IMvcContext mvcContext, ICardService cardService) : base(mvcContext)
        {
            _cardService = cardService;
        }

        public ActionResult Card()
        {
            var vm = _cardService.Get(_mvcContext);
            return View("~/Areas/Feature/Card/Views/Card/Card.cshtml", vm);
        }
    }
}