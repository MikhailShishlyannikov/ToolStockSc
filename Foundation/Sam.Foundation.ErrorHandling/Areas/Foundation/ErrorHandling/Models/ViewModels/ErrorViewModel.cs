using System;

namespace Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Models.ViewModels
{
    public class ErrorViewModel
    {
        public Guid Id { get; set; }

        public string StatusCode { get; set; }

        public string Message { get; set; }

        public string LinkText { get; set; }
    }
}