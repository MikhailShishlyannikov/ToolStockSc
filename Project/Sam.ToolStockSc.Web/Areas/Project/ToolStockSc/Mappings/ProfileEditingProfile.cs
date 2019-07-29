using System;
using System.Linq;
using AutoMapper;
using Glass.Mapper.Sc;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Security.Accounts;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Mappings
{
    public class ProfileEditingProfile : Profile
    {
        public ProfileEditingProfile()
        {
            CreateMap<User, ProfileEditingViewModel>()
                .ForMember(vm => vm.Name, opt => opt.MapFrom(u => u.Profile["UserName"]))
                .ForMember(vm => vm.Patronymic, opt => opt.MapFrom(u => u.Profile["Patronymic"]))
                .ForMember(vm => vm.Surname, opt => opt.MapFrom(u => u.Profile["Surname"]))
                .ForMember(vm => vm.Email, opt => opt.MapFrom(u => u.Profile.Email))
                .ForMember(vm => vm.Phone, opt => opt.MapFrom(u => u.Profile["Phone"]))
                .ForMember(vm => vm.Role, opt => opt.MapFrom(u => u.Roles.FirstOrDefault().Name.Split('\\')[1]))
                .ForMember(vm => vm.Department, 
                    opt => opt.MapFrom(
                        u => 
                            new SitecoreService(SitecoreConstants.MasterDatabase.Master).GetItem<DepartmentScModel>(Guid.Parse(u.Profile["Department"]))));
        }
    }
}