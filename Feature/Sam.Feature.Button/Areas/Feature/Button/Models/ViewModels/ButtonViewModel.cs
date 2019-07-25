using Glass.Mapper.Sc.Fields;
using System;

namespace Sam.Feature.Button.Areas.Feature.Button.Models.ViewModels
{
    public class ButtonViewModel
    {
        public Guid Id { get; set; }

        public Link Link { get; set; }

        public string Class { get; set; }
    }
}