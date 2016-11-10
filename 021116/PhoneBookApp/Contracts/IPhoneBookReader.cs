﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Contracts
{
    public interface IPhoneBookReader
    {
        List<Person> ReadRecords();
        Person CreatePerson(string personLine);
    }
}