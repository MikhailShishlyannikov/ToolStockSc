using System;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;

namespace Sam.Foundation.GlassMapper.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMvcContext _mvcContext;

        public BaseController(IMvcContext mvcContext)
        {
            if (mvcContext == null)
            {
                throw new ArgumentNullException(nameof(mvcContext));
            }
            _mvcContext = mvcContext;
        }
    }
}