﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Contracts
{
    public interface IReader
    {
        int Read();
        string ReadLine();
    }
}
