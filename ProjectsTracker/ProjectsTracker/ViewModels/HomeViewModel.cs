using PagedList;
using ProjectsTracker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectsTracker.ViewModels
{
    public class HomeViewModel
    {
        public IDictionary<string, double> Statistics { get; set; }
        
        public IPagedList<ProjectViewModel> Projects { get; set; }

        public HomeViewModel( IPagedList<ProjectViewModel> projects, IDictionary<string, double> statistics)
        {
            this.Projects = projects;
            this.Statistics = statistics;       
        }
    }
}