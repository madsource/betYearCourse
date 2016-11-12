using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using PhoneBookApp.Contracts;

namespace PhoneBookApp
{
    public abstract class Serializator<T> : ISerializator<T>
    {

        //public IWriter Writer { get; protected set; }
        //public IReader Reader { get; protected set; }


        //public Serializator(IWriter writer, IReader reader)
        //{
        //    this.Writer = writer;
        //    this.Reader = reader;
        //}       

        public abstract void Serialize(IWriter writer , T obj);

        public abstract T Deserialize(IReader reader);
    }
}
