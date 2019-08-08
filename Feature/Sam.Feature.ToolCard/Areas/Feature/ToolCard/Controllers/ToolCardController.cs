using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.ToolCard.Areas.Feature.ToolCard.Logic.Interfaces;
using Sam.Foundation.GlassMapper.Controllers;

namespace Sam.Feature.ToolCard.Areas.Feature.ToolCard.Controllers
{
    public class ToolCardController : BaseController
    {
        private readonly IToolCardService _toolCardService;

        public ToolCardController(IMvcContext mvcContext, IToolCardService toolCardService) : base(mvcContext)
        {
            _toolCardService = toolCardService;
        }

        // GET: Feature/ToolCard
        public ActionResult ToolCard()
        {
            var vm = _toolCardService.GetViewModel(_mvcContext);

            return View("~/Areas/Feature/ToolCard/Views/ToolCard/ToolCard.cshtml", vm);
        }
    }
}