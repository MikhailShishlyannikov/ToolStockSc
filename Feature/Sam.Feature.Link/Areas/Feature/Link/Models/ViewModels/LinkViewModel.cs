using System;
using LinkSc = Glass.Mapper.Sc.Fields.Link;

namespace Sam.Feature.Link.Areas.Feature.Link.Models.ViewModels
{
    public class LinkViewModel
    {
        public Guid Id { get; set; }

        public LinkSc Link { get; set; }
    }
}