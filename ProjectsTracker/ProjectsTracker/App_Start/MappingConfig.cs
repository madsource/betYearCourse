using System.Linq;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectsTracker.Data;
using ProjectsTracker.Models;
using ProjectsTracker.ViewModels;

namespace ProjectsTracker
{
    public static class MappingConfig
    {

        public static void RegisterMaps()
        {

            AutoMapper.Mapper.Initialize(config =>
            {
                //Application user
                config.CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(s => s.Roles.FirstOrDefault().RoleId));

                config.CreateMap<ApplicationUserViewModel, ApplicationUser>()
                    .ForMember(dest => dest.Roles, opt => opt.Ignore());
                //Project
                config.CreateMap<Project, ProjectViewModel>().ReverseMap();
                //PTask
                config.CreateMap<PTask, PTaskViewModel>()
                 .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(u => u.Owner.Id));

                config.CreateMap<PTaskViewModel, PTask>()
                .ForMember(dest => dest.Owner, opt => opt.Ignore());

                config.CreateMap<TimeReportItem, TimeReportItemViewModel>().ReverseMap();

            });
        }
    }
}