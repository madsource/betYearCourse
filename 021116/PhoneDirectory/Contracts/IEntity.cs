﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Contracts
{
    public interface IEntity
    {
        string Name { get; set; }
        string CityName { get; set; }
        string PhoneNumber { get; set; }

        string ToString();
    }
}
