using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Link.Areas.Feature.Link.Models.ScModels;
using Sam.Feature.Link.Areas.Feature.Link.Models.ViewModels;
using Sam.Foundation.GlassMapper.Controllers;
using System.Web.Mvc;

namespace Sam.Feature.Link.Areas.Feature.Link.Controllers
{
    public class LinkController : BaseController
    {
        public LinkController(IMvcContext mvcContext) : base(mvcContext)
        {
        }

        // GET: Feature/Link
        public ActionResult Link()
        {
            var model = new LinkViewModel(_mvcContext.GetDataSourceItem<LinkScModel>());
            return View("~/Areas/Feature/Link/Views/Link/Link.cshtml", model);
        }
    }
}