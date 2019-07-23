using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class NavLinkViewModel
    {
        public Guid Id { get; set; }
        public Link Link { get; set; }
        public string Icon { get; set; }
    }
}