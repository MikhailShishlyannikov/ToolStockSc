using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sam.Feature.Button.Areas.Feature.Button.Controllers
{
    public class ButtonController : BaseController
    {
        public ButtonController(IMvcContext mvcContext) : base(mvcContext)
        {

        }

        // GET: Feature/Button
        public ActionResult Index()
        {
            return View();
        }
    }
}