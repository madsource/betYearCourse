﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTracker.Models
{
    public abstract class BaseModel
    {

        public int Id { get; set; }
   
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
