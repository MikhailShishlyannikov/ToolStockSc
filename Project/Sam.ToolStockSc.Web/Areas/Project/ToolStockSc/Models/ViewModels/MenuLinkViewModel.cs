using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class MenuLinkViewModel
    {
        public Guid Id { get; set; }

        public Link Link { get; set; }

        public IList<string> Icons { get; set; }
    }
}