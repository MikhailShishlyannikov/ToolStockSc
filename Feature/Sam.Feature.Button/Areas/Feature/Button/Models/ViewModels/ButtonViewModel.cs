using Glass.Mapper.Sc.Fields;
using Sam.Feature.Button.Areas.Feature.Button.Models.Rendering_Parameters;
using Sam.Feature.Button.Areas.Feature.Button.Models.ScModels;
using System;

namespace Sam.Feature.Button.Areas.Feature.Button.Models.ViewModels
{
    public class ButtonViewModel
    {
        public ButtonViewModel(ButtonScModel datasource, ButtonRP renderingParameters)
        {
            if (datasource != null)
            {
                Id = datasource.Id;
                Link = datasource.Link;
            }

            if (renderingParameters != null)
            {
                Class = $"btn {renderingParameters.Style?.Class}";
            }
        }
        public Guid Id { get; set; }

        public Link Link { get; set; }

        public string Class { get; set; }
    }
}