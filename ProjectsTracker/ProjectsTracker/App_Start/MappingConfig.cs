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
                config.CreateMap<Project, ProjectViewModel>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.FirstName + src.Owner.LastName));

                config.CreateMap<ProjectViewModel, Project>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => new ApplicationUser()
                    {
                        Id = src.OwnerId
                    }));
            });
        }
    }
}