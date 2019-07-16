using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using System;
using System.Collections.Generic;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class RegisterViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string NameField { get; set; }

        public string Patronymic { get; set; }
        public string PatronymicField { get; set; }

        public string Surname { get; set; }
        public string SurnameField { get; set; }

        public string Phone { get; set; }
        public string PhoneField { get; set; }

        public string Email { get; set; }
        public string EmailField { get; set; }

        public string Password { get; set; }
        public string PasswordField { get; set; }

        public string ConfirmPassword { get; set; }
        public string ConfirmPasswordField { get; set; }

        public Guid DepartmentId { get; set; }
        public string DepartmentField { get; set; }

        public IList<DepartmentScModel> Departments { get; set; }
    }
}