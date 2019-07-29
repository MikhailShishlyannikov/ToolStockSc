using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class ProfileEditingViewModel
    {
        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Role { get; set; }

        public DepartmentScModel Department { get; set; }

        public string Stock { get; set; }

        public ProfileEditingScModel ScModel { get; set; }
    }
}