using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.TableCard.Areas.Feature.TableCard.Logic.Interfaces;
using Sam.Foundation.GlassMapper.Controllers;

namespace Sam.Feature.TableCard.Areas.Feature.TableCard.Controllers
{
    public class TableCardController : BaseController
    {
        private readonly ITableCardService _tableCardService;

        public TableCardController(IMvcContext mvcContext, ITableCardService tableCardService) : base(mvcContext)
        {
            _tableCardService = tableCardService;
        }

        public ActionResult TableCard()
        {
            var vm = _tableCardService.Get(_mvcContext);

            return View("~/Areas/Feature/TableCard/Views/TableCard/TableCard.cshtml", vm);
        }
    }
}