using Glass.Mapper.Sc.Fields;
using System;
using Sitecore.Data.Items;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class LogoLinkViewModel
    {
        public Guid Id { get; set; }
        public Link Link { get; set; }

        public Image Logo {get; set;}
    }
}