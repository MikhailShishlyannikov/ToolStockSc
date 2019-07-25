using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Link.Areas.Feature.Link.Logic.Interfaces;
using Sam.Foundation.GlassMapper.Controllers;
using System.Web.Mvc;

namespace Sam.Feature.Link.Areas.Feature.Link.Controllers
{
    public class LinkController : BaseController
    {
        private readonly ILinkService _linkService;

        public LinkController(IMvcContext mvcContext, ILinkService linkService) : base(mvcContext)
        {
            _linkService = linkService;
        }

        // GET: Feature/Link
        public ActionResult Link()
        {
            var vm = _linkService.Get(_mvcContext);
            return View("~/Areas/Feature/Link/Views/Link/Link.cshtml", vm);
        }
    }
}