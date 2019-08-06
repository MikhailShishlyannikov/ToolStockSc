using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class ToolViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [StringLength(60)]
        public string Manufacturer { get; set; }

        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        public Guid StatusId { get; set; }

        public IList<StatusScModel> Statuses { get; set; }

        public Guid ToolTypeId { get; set; }

        public IList<ToolTypeScModel> ToolTypes { get; set; }

        public Guid StockId { get; set; }

        public IList<StockScModel> Stocks { get; set; }

        public string UserName{ get; set; }

        public IList<UserReferenceScModel> Users { get; set; }

        public ToolCreatingScModel ScModel { get; set; }
    }
}