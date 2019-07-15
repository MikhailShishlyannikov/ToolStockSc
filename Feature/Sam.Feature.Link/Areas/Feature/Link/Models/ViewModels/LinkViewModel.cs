using Sam.Feature.Link.Areas.Feature.Link.Models.ScModels;
using System;
using LinkSc = Glass.Mapper.Sc.Fields.Link;

namespace Sam.Feature.Link.Areas.Feature.Link.Models.ViewModels
{
    public class LinkViewModel
    {
        public LinkViewModel(LinkScModel datasource)
        {
            if (datasource != null)
            {
                Id = datasource.Id;
                Link = datasource.Link;
            }
        }

        public Guid Id { get; set; }

        public LinkSc Link { get; set; }
    }
}