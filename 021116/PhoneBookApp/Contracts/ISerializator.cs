﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Contracts
{
    interface ISerializator<T>
    {
        void Serialize(IWriter writer, T obj);
        T Deserialize(IReader reader);
    }
}
