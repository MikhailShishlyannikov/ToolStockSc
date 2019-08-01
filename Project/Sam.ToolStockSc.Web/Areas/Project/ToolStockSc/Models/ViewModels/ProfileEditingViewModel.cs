using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using System.ComponentModel.DataAnnotations;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class ProfileEditingViewModel
    {
        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(70)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(80)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Role { get; set; }

        public DepartmentScModel Department { get; set; }

        public StockScModel Stock { get; set; }

        public ProfileEditingScModel ScModel { get; set; }
    }
}