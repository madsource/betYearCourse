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
                .ForMember(dest => dest.userRoles, opt => opt.Ignore());
                config.CreateMap<ApplicationUserViewModel, ApplicationUser>();

                //Project
                config.CreateMap<Project, ProjectViewModel>().ReverseMap();

                //PTask
                config.CreateMap<PTask, PTaskViewModel>();     
                config.CreateMap<PTaskViewModel, PTask>();

                // TimeReportItem
                config.CreateMap<TimeReportItem, TimeReportItemViewModel>().ReverseMap();

            });
        }
    }
}