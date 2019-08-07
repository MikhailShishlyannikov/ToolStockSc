using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.DependencyInjection;
using Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Logic.Interfaces;
using Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Models.ScModels;
using Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Models.ViewModels;

namespace Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Logic.Services
{
    [Service(typeof(IErrorService))]
    public class ErrorService : IErrorService
    {
        private readonly IMapper _mapper;

        public ErrorService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ErrorViewModel GetViewModel(IMvcContext mvcContext)
        {
            return _mapper.Map<ErrorViewModel>(mvcContext.GetDataSourceItem<ErrorScModel>());
        }
    }
}